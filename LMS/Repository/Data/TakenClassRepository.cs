using LMS.Context;
using LMS.Models;
using LMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace LMS.Repository.Data
{
    public class TakenClassRepository : GeneralRepository<MyContext, TakenClass, int>
    {
        private readonly MyContext myContext;

        //Constructor
        public TakenClassRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        //Cek Email Apakah Ada di Database
        public int CekEmail(string inputEmail)
        {
            var cek = myContext.Accounts.SingleOrDefault(u => u.Email == inputEmail);
            if (cek != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //Cek Id Class Apakah Ada di Database
        public bool CekClassId(int inputId)
        {
            var cek = myContext.Classes.Where(x => x.Id == inputId);
            if (cek != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Register DaftarKelas
        public int RegisterTakenClass(RegisterTakenClassVM inputData)
        {
            //Cek Data TakenClass dengan Email dan Class_Id yang diinput apakah sudah ada
            var cek = myContext.TakenClasses.FirstOrDefault(x => (x.Email == inputData.Email) && (x.Class_Id == inputData.Class_Id));

            if (cek == null)
            {
                //Siapkan Object Untuk Menampung Data TakenClass
                TakenClass dataTakenClass = new TakenClass()
                {
                    Email = inputData.Email,
                    ProgressChapter = 0,
                    IsDone = false,
                    OrderId = $"Pay_{inputData.Email}_{inputData.Class_Id}_{DateTime.Now.ToString("MM-dd-yyyyHH:mm")}",
                    Expired = DateTime.Now.AddDays(1),
                    IsPaid = false,  // Nanti diganti false
                    Class_Id = inputData.Class_Id
                };

                //Insert Ke Database TakenClass
                myContext.TakenClasses.Add(dataTakenClass);
                myContext.SaveChanges();

                //Sukses Register TakenClass
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //Get TakenClassLengkap
        public List<TakenClassVM> GetTakenClassLengkap()
        {
            var data = myContext.TakenClasses
                .Join(myContext.Classes, t => t.Class_Id, c => c.Id, (t, c) => new { t, c })
                .Join(myContext.Levels, tc => tc.c.Level_Id, l => l.Id, (tc, l) => new { tc, l })
                .Join(myContext.Categories, tcl => tcl.tc.c.Category_Id, ct => ct.Id, (tcl, ct) => new { tcl, ct })
                .Select(dt => new TakenClassVM()
                {
                    TakenClass_Id = dt.tcl.tc.t.Id,
                    Email = dt.tcl.tc.t.Email,
                    TakenClass_ProgressChapter = dt.tcl.tc.t.ProgressChapter,
                    TakenClass_IsDone = dt.tcl.tc.t.IsDone,
                    TakenClass_OrderId = dt.tcl.tc.t.OrderId,
                    TakenClass_IsPaid = dt.tcl.tc.t.IsPaid,
                    TakenClass_Expired = dt.tcl.tc.t.Expired,
                    Class_Id = dt.tcl.tc.t.Class_Id,
                    Class_Name = dt.tcl.tc.c.Name,
                    Class_Desc = dt.tcl.tc.c.Desc,
                    Class_Rating = dt.tcl.tc.c.Rating,
                    Class_TotalChapter = dt.tcl.tc.c.TotalChapter,
                    Class_Level = dt.tcl.l.Name,
                    Class_Category = dt.ct.Name,
                    Class_Price = dt.tcl.tc.c.Price
                }).ToList();
            return data;
        }

        //Get TakenClass By Email
        public List<TakenClassVM> GetTakenClassByEmail(string inputEmail)
        {
            var data = GetTakenClassLengkap().Where(d => (d.Email == inputEmail) && (d.TakenClass_IsPaid == true)).ToList();
            return data;
        }

        //Get Taken Class By Email and IsDone
        public List<TakenClassVM> GetTakenClassByIsDone(TakenClassIsDoneVM inputData)
        {
            var data = GetTakenClassByEmail(inputData.Email).Where(d => d.TakenClass_IsDone == Convert.ToBoolean(inputData.IsDone) && (d.TakenClass_IsPaid == true)).ToList();
            return data;
        }

        //Get Taken Class By Class_Id
        public List<TakenClassVM> GetTakenClassByClassId(int id)
        {
            var data = GetTakenClassLengkap().Where(x => x.Class_Id == id).ToList();
            return data;
        }

        //Get Taken Class By Email and Class_Id
        public TakenClassVM GetTakenClassByEmailClassId(string inputEmail, int inputId)
        {
            var data = GetTakenClassLengkap().FirstOrDefault(x => x.Class_Id == inputId && x.Email == inputEmail);
            return data;
        }

        //Next Chapter
        public int NextChapter(RegisterTakenClassVM inputData)
        {
            //Ambil data TakenClass By Email dan ClassId
            var dataTakenClass = GetTakenClassByEmail(inputData.Email).Where(x => x.Class_Id == inputData.Class_Id).FirstOrDefault();

            var dataTC = myContext.TakenClasses.SingleOrDefault(x => x.Id == dataTakenClass.TakenClass_Id);

            //Cek Apakah ProgressChapter < TotalChapter
            if (dataTakenClass.TakenClass_ProgressChapter < dataTakenClass.Class_TotalChapter - 1)
            {
                //Siapkan Object Untuk Menampung Data Update TakenClass
                TakenClass updateTakenClass = new TakenClass()
                {
                    Id = dataTakenClass.TakenClass_Id,
                    Email = inputData.Email,
                    ProgressChapter = dataTakenClass.TakenClass_ProgressChapter + 1,
                    IsDone = false,
                    OrderId = dataTakenClass.TakenClass_OrderId,
                    Expired = dataTakenClass.TakenClass_Expired,
                    IsPaid = dataTakenClass.TakenClass_IsPaid,
                    Class_Id = dataTakenClass.Class_Id
                };

                //Proses Update 
                myContext.Entry(dataTC).CurrentValues.SetValues(updateTakenClass);
                myContext.SaveChanges();

                // Sukses Chapter Bertambah
                return 1;
            }
            else
            {
                //Siapkan Object Untuk Update Data TakenClass
                TakenClass updateTakenClass = new TakenClass()
                {
                    Id = dataTakenClass.TakenClass_Id,
                    Email = inputData.Email,
                    ProgressChapter = dataTakenClass.TakenClass_ProgressChapter + 1,
                    IsDone = true,
                    OrderId = dataTakenClass.TakenClass_OrderId,
                    Expired = dataTakenClass.TakenClass_Expired,
                    IsPaid = dataTakenClass.TakenClass_IsPaid,
                    Class_Id = dataTakenClass.Class_Id,
                };

                //Proses Update 
                myContext.Entry(dataTC).CurrentValues.SetValues(updateTakenClass);
                myContext.SaveChanges();

                // Chapter Terselesaikan semua
                return -1;
            }
        }

        // Get Taken Class By email Yang Belum Bayar
        //Mendapatkan Daftar TakenClass Berdasarkan Usernya siapa dan Belum Bayar
        public List<TakenClassVM> GetTakenClassByIsPaidFalse(TakenClassVM inputData)
        {
            //Ambil Data
            var data = GetTakenClassLengkap().Where(d => (d.Email == inputData.Email) && (d.TakenClass_IsPaid == false)).ToList();
            return data;
        }

        //Get Taken Class By Order_Id
        //Mendapatkan Data TakenClass Berdasarkan Order_Id TakenClass -> hasil 1 data saja
        public TakenClassVM GetTakenClassByOrderId(TakenClassVM inputData)
        {
            //Ambil Data
            var data = GetTakenClassLengkap().FirstOrDefault(d => d.TakenClass_OrderId == inputData.TakenClass_OrderId);
            return data;
        }

        //Bayar Menggunakan Midtrans
        public async Task<object> Bayar(string inputEmail, string inputOrderId, int inputClassId)
        {
            //Ambil data class sesuai dengan inputClassId
            var dataClass = myContext.Classes.SingleOrDefault(x => x.Id == inputClassId);
            var dataUser = myContext.Users.SingleOrDefault(x => x.Email == inputEmail);

            //Call Post API MidTrans
            string url = "https://app.sandbox.midtrans.com/snap/v1/transactions";
            var client = new RestClient(url);
            var request = new RestRequest();
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic U0ItTWlkLXNlcnZlci1sdHhEaS1iQ3hMSGV6Z281MlRHa183cXA6");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                transaction_details = new
                {
                    order_id = inputOrderId,
                    gross_amount = dataClass.Price
                },
                credit_card = new
                {
                    secure = true
                },
                item_details = new
                {
                    id = dataClass.Id,
                    price = dataClass.Price,
                    quantity = 1,
                    name = dataClass.Name
                },
                customer_details = new
                {
                    first_name = dataUser.FirstName,
                    last_name = dataUser.LastName,
                    email = dataUser.Email,
                    phone = dataUser.Phone
                }
            });

            var response = await client.PostAsync(request);
            var result = JsonConvert.DeserializeObject(response.Content);
            return result;
        }

        // Konfirmasi Pembayaran Midtrans
        public async Task<int> KonfirmasiBayar(string inputEmail, int inputClassId)
        {
            //Ambil data takenclass berdasarkan email dan class_id
            var dataTC = GetTakenClassLengkap().SingleOrDefault(x => x.Email == inputEmail && x.Class_Id == inputClassId);
            var dataTakenClass = myContext.TakenClasses.SingleOrDefault(x => x.Email == inputEmail && x.Class_Id == inputClassId);
            if (dataTC != null)
            {
                //Ambil data dari midtrans
                var dataStatus = await StatusPembayaran(dataTC.TakenClass_OrderId);

                //Cek Status
                if (dataStatus == "settlement") // -> sudah dibayar (sebelum batas waktu)
                {
                    //Siapkan variabel object untuk menampung data TakenClass yang akan diupdate
                    TakenClass updateTC = new TakenClass()
                    {
                        Id = dataTC.TakenClass_Id,
                        Email = dataTC.Email,
                        ProgressChapter = dataTC.TakenClass_ProgressChapter,
                        IsDone = dataTC.TakenClass_IsDone,
                        OrderId = dataTC.TakenClass_OrderId,
                        Expired = dataTC.TakenClass_Expired,
                        IsPaid = true,
                        Class_Id = dataTC.Class_Id
                    };

                    //karena sudah bayar -> update data TakenClass IsPaid menjadi true
                    myContext.Entry(dataTakenClass).CurrentValues.SetValues(updateTC);
                    myContext.SaveChanges();

                    return 1; //pembayaran berhasil
                }
                else if (dataStatus == "pending") // -> belum bayar tapi belum melewati batas waktu
                {
                    //karena belum bayar tapi masih belom lewat batas waktu ya tidak diapa-apain
                    return -1;
                }
                else // -> sudah expired atau belum bayar dan sudah lewat batas waktu
                {
                    //hapus data TakenClass
                    myContext.TakenClasses.Remove(dataTakenClass);
                    myContext.SaveChanges();

                    return 0;
                }
            }
            else
            {
                return -2; // -> data takenclass tidak ada (belum mendaftar)
            }
        }

        // Get API Status order_id ke Midtrans
        public async Task<string> StatusPembayaran(string orderId)
        {
            string url = $"https://api.sandbox.midtrans.com/v2/{orderId}/status";
            var client = new RestClient(url);
            var request = new RestRequest();
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic U0ItTWlkLXNlcnZlci1sdHhEaS1iQ3hMSGV6Z281MlRHa183cXA6");

            var response = await client.GetAsync(request);
            var status = JsonConvert.DeserializeObject<KonfirmasiMidtransVM>(response.Content);
            return status.transaction_status.ToString();
        }

        public int RegisterTCFree(RegisterTakenClassVM inputData)
        {
            //Cek data apakah ada di database
            var cek = myContext.TakenClasses.FirstOrDefault(x => (x.Email == inputData.Email) && (x.Class_Id == inputData.Class_Id));

            if (cek == null)
            {
                // buat variabel yang menampung data TakenClass
                TakenClass newData = new TakenClass()
                {
                    Email = inputData.Email,
                    ProgressChapter = 0,
                    IsDone = false,
                    OrderId = $"Pay_{inputData.Email}_{inputData.Class_Id}_{DateTime.Now.ToString("MM-dd-yyyyHH:mm")}",
                    Expired = DateTime.Now.AddDays(1),
                    IsPaid = true,  // -> harga 0 = sudah bayar
                    Class_Id = inputData.Class_Id
                };

                //Insert Ke Database TakenClass
                myContext.TakenClasses.Add(newData);
                myContext.SaveChanges();

                //Sukses Register TakenClass
                return 1;
            }
            else
            {
                return -1; // -> data email dan Class_Id tidak ada
            }
        }
    }
}