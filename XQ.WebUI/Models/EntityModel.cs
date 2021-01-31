using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XQ.WebUI.Models
{
	public class EntityModel
	{

	}

	/// <summary>
	/// 部门的表格Model
	/// </summary>
	public class DepartmentModel
	{
		public int DepartmentId { get; set; }
		
		public string DepartmentName { get; set; }
	}

	/// <summary>
	/// 员工的表格Model
	/// </summary>
	public class StaffModel
	{
		public int StadffId { get; set; }

		public string DepartmentName { get; set; }

		public string StaffName { get; set; }

		public bool IsManager { get; set; }

		public bool ActiveFlag { get; set; }
	}

	/// <summary>
	/// 项目的表格Model
	/// </summary>
	public class ProjectModel
	{
		public int ProjectId { get; set; }
		
		public string ProjectCode { get; set; }
		
		public string ProjectDesc { get; set; }
	}

	/// <summary>
	/// 机台的表格Model
	/// </summary>
	public class CustomerModel
	{
		public int CustomerId { get; set; }

		public Nullable<int> ProjectId { get; set; }

		public string CustomerCode { get; set; }

		public string CustomerName { get; set; }
	}

	/// <summary>
	/// 任务的表格Model
	/// </summary>
	public class WorkModel
	{
		public int WorkId { get; set; }

		public Nullable<int> ProjectId { get; set; }

		public Nullable<int> CustomerId { get; set; }

		public Nullable<int> DepartmentId { get; set; }

		public string DepartmentName { get; set; }

		public string WorkSummary { get; set; }

		public Nullable<System.DateTime> ScheduleStart { get; set; }

		public Nullable<System.DateTime> ScheduleEnd { get; set; }

		public Nullable<double> EstimateHours { get; set; }

		public Nullable<System.DateTime> ActualStart { get; set; }

		public Nullable<System.DateTime> ActualEnd { get; set; }

		public Nullable<double> ActualHours { get; set; }

		/// <summary>
		/// 完成状态:
		/// Scheduled=0,
		/// Started=10,
		/// Completed=20,
		/// Canceled=30,
		/// 过去的Termitated=40
		/// </summary>
		public Nullable<int> CompleteFlag { get; set; }
	}

	/// <summary>
	/// 汇报的表格Model
	/// </summary>
	public class WorkReportModel
	{
		public int Id { get; set; }
		
		public Nullable<int> WorkId { get; set; }
		
		public Nullable<int> StaffId { get; set; }
		
		public string StaffName { get; set; }
		
		public Nullable<System.DateTime> ReportTime { get; set; }
		
		public Nullable<double> WorkHours { get; set; }
		
		public string ReportText { get; set; }
	}

	/// <summary>
	/// 主界面综合报表
	/// </summary>
	public class ReportInfo
	{
		public string ProjectCode { get; set; }
	}
}