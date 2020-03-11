using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //Nho dua ve public
    public class AccountModel
    {
        private QuanLyQuanAnDbContext context = null;
        private static QuanLyQuanAnDbContext staticContex=new QuanLyQuanAnDbContext();
        public AccountModel()
        {
            context = new QuanLyQuanAnDbContext();
        }
        public bool Login(string userName, string password)
        {
            string passwordHash = CalculateMD5Hash(userName+""+password);//nen hash them username
            object[] sqlParams =
            {
                new SqlParameter("@UserName",userName),
                new SqlParameter("@Password", passwordHash),
            };
            var res = context.Database.SqlQuery<Int32>("Sp_Account_Login @UserName, @Password", sqlParams).SingleOrDefault();
            if (res == 1)
                return true;
            else
                return false;
        }

        public string ChangePassword(string tendangnhap, string oldPass, string newPass)
        {
            //Get mk cu
            string oldPasswordHash = CalculateMD5Hash(tendangnhap + "" + oldPass);
            var ktMKCu = context.Database.SqlQuery<int>("select count(*) from ACCOUNT where TAIKHOAN='" + tendangnhap + "' and MATKHAU='"+ oldPasswordHash + "'").First();
            if (ktMKCu < 1)
                return "Đổi mật khẩu thất bại! Mật khẩu cũ không chính xác!";
            else
            {
                string newPassHash = CalculateMD5Hash(tendangnhap + "" + newPass);
                if (oldPasswordHash == newPassHash)
                    return "Mật khẩu mới giống mật khẩu cũ!";
                string command = "UPDATE ACCOUNT SET MATKHAU='"+ newPassHash + "' where MATKHAU='"+oldPasswordHash+ "' and TAIKHOAN='"+tendangnhap+"'";
                var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(command);
                if (res > 0)
                    return "Đổi mật khẩu thành công!";
                else
                    return "Đổi mật khẩu thất bại!";
            }
        }

        public bool UpdateInfo(string userID, string hoTen, string gioiTinh, string ngaySinh, string sdt, string taiKhoan, string diaChi)
        {
            string command = "Sp_ACCOUNT_Update @userID= '"+userID+"' , @hoTen=N'"+hoTen+"', @gioiTinh=N'"+gioiTinh+"', @ngaySinh='"+ngaySinh+"', @sdt ='"+sdt+"', @taiKhoan ='"+taiKhoan+"' , @diaChi =N'"+diaChi+"'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(command);
            if (res > 0)
                return true;
            else
                return false;
        }

        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string GetLoaiUser(string tendangnhap)
        {
            try
            {
                var res = staticContex.Database.SqlQuery<string>("select LOAIUSER from ACCOUNT where TAIKHOAN='" + tendangnhap + "'").First();
                return res;
            }
            catch
            {
                return "";
            }
        }
        
        public string GetID(string tenDangNhap)
        {
            try
            {
                var res = staticContex.Database.SqlQuery<string>("select ID from ACCOUNT where TAIKHOAN='" + tenDangNhap + "'").First();
                return res;
            }
            catch
            {
                return "";
            }
        }
        
        public bool Register(string hoten,string username,string pass)
        {
            string maMoiNhat = new QuanLyQuanAnDbContext().Database.SqlQuery<string>("Sp_KHACHHANG_GetMaKhachHangLast").First();
            string newMa = maMoiNhat.Remove(0, 2);
            int newNum = Int32.Parse(newMa) + 1;
            newMa = newNum + "";
            int l = newMa.Length;
            for (int i = 0; i < maMoiNhat.Length - 2 - l; i++)
            {
                newMa = "0" + newMa;
            }
            newMa = "kh" + newMa;

            string passHash = CalculateMD5Hash(username+""+pass);
            //insert
            string insertCommand = "Sp_ACCOUNT_Insert @id='"+newMa+"' ,@hoten=N'" + hoten + "', @username='" + username + "',@pass='"+ passHash + "'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(insertCommand);
            if (res > 0)
                return true;
            else
                return false;
        }
    }
}
