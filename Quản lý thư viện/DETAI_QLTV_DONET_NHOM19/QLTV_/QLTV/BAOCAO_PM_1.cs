using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace QLTV
{
    public partial class BAOCAO_PM_1 : Form
    {
        SqlConnection connection;
        string str = DataHolder.str;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public BAOCAO_PM_1()
        {
            InitializeComponent();
        }

        private void BAOCAO_PM_1_Load(object sender, EventArgs e)
        {
           

        
            if (DATA_RP.check == 1)
            {
                
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    // Truy vấn dữ liệu từ bảng PhieuMuon
                    string query = "SELECT * FROM PhieuMuon Where TinhTrang = N'Chưa trả' and NgayMuon >= @NgayMuon or TinhTrang = N'Quá hạn' and NgayMuon >= @NgayMuon";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NgayMuon", DATA_RP.date);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Gán dữ liệu từ bảng PhieuMuon cho DataGridView dgv_Sach

                            // Tạo ReportDataSource
                            ReportDataSource reportDataSource = new ReportDataSource("dataSetPM", dt);
                          

                           
                            // Đặt báo cáo cho ReportViewer
                            reportViewer1.LocalReport.ReportPath = "BAOCAO.rdlc";

                            // Tạo và đặt giá trị cho tham số "StartDateParam"
                            ReportParameter startDateParam = new ReportParameter("StartDateParam", DateTime.Now.Month.ToString());
                            reportViewer1.LocalReport.SetParameters(startDateParam);
                          
                            reportViewer1.LocalReport.DataSources.Clear();
                            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                            // Cập nhật báo cáo
                            reportViewer1.RefreshReport();
                        }
                    }
                }
            }
            else if (DATA_RP.check == 2)
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    // Truy vấn dữ liệu từ bảng PhieuMuon
                    string query = "SELECT * FROM PhieuMuon Where TinhTrang = N'Đã trả' and NgayMuon >= @NgayMuon";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NgayMuon", DATA_RP.date);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Gán dữ liệu từ bảng PhieuMuon cho DataGridView dgv_Sach


                            // Tạo ReportDataSource
                            ReportDataSource reportDataSource = new ReportDataSource("dataSetPM_1", dt);
                          
                            // Đặt báo cáo cho ReportViewer
                            reportViewer1.LocalReport.ReportPath = "BAOCAO_1.rdlc";
                            ReportParameter startDateParam = new ReportParameter("StartDateParam", DateTime.Now.Month.ToString());
                            reportViewer1.LocalReport.SetParameters(startDateParam);
                            reportViewer1.LocalReport.DataSources.Clear();
                            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                            // Cập nhật báo cáo
                            reportViewer1.RefreshReport();
                        }
                    }
                }
            }
            else if (DATA_RP.check == 3)
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    // Truy vấn dữ liệu từ bảng PhieuMuon
                    string query = "SELECT * FROM PhieuMuon  Where NgayMuon >= @NgayMuon";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NgayMuon", DATA_RP.date);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Gán dữ liệu từ bảng PhieuMuon cho DataGridView dgv_Sach


                            // Tạo ReportDataSource
                            ReportDataSource reportDataSource = new ReportDataSource("dataSetPM_2", dt);
                          
                            // Đặt báo cáo cho ReportViewer
                            reportViewer1.LocalReport.ReportPath ="BAOCAO_2.rdlc";
                            ReportParameter startDateParam = new ReportParameter("StartDateParam", DateTime.Now.Month.ToString());
                            reportViewer1.LocalReport.SetParameters(startDateParam);
                            reportViewer1.LocalReport.DataSources.Clear();
                            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                            // Cập nhật báo cáo
                            reportViewer1.RefreshReport();
                        }
                    }
                }
            }
           
        }
    }
}
