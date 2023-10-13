j﻿using lap4._1.Model;
using lap4._1.report.StudentReport;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lap4._1
{
    public partial class FrmReport : Form
    {
        //toantran đa o day 
        //jhgfd
        
        public FrmReport()
        {
            InitializeComponent();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            StudentContextDB db = new StudentContextDB();

            var listStudentReportDto = db.Students.Select(c=> new StudentReportDto 
            {
            StudentID =c.StudentID,
            FullName =c.FullName,
            AverageScore =c.AverageScore,
            
            }).ToList();
/// hao da toi day
            this.reportViewer1.LocalReport.ReportPath = "rptStudentReport.rdlc";
            var reportDataSource = new ReportDataSource("StudentReportDataSet", listStudentReportDto);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.Refresh();

            this.reportViewer1.RefreshReport();
        }
    }
}
