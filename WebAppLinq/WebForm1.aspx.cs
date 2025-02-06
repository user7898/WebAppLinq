using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppLinq
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataContext dataContext = new DataContext(@"data source=LAPTOP-QCUS1N83;initial catalog=Test_LINQ_TwoLayer; Integrated security=true");
                Table<Employee> employees = dataContext.GetTable<Employee>();
                //GridView1.DataSource = employees;
                //GridView1.DataBind();

                //var m = from emp in employees where emp.Salary > 25000 select emp;
                //GridView1.DataSource = m;
                //GridView1.DataBind();


                //var m1 = from emp in employees select new { Name = emp.Name, Salary = emp.Salary };
                //GridView1.DataSource = m1;
                //GridView1.DataBind();

                var m2 = from emp in employees select new { Name = emp.Name, Id = emp.Id };
                DropDownList1.DataSource = m2;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "Id";
                DropDownList1.DataBind();

                DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));

            }
        }



        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DataContext dataContext = new DataContext(@"data source=LAPTOP-QCUS1N83;initial catalog=Test_LINQ_TwoLayer; Integrated security=true");
            Table<Employee> employees = dataContext.GetTable<Employee>();
            var m2 = from emp in employees where emp.Id == Convert.ToInt32(DropDownList1.SelectedItem.Value) select emp;
            GridView1.DataSource = m2;
            GridView1.DataBind();


            foreach (Employee emp in m2)
            {
                TextBox1.Text = emp.Name;
                TextBox2.Text = emp.Job;
                TextBox3.Text = emp.Salary.ToString();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataContext dataContext = new DataContext(@"data source=LAPTOP-QCUS1N83;initial catalog=Test_LINQ_TwoLayer; Integrated security=true");
            Table<Employee> employees = dataContext.GetTable<Employee>();
            Employee emp = new Employee { Id = Convert.ToInt32(TextBox5.Text), Name = TextBox1.Text, Job = TextBox2.Text, Salary = Convert.ToInt32(TextBox3.Text) };
            employees.InsertOnSubmit(emp);
            dataContext.SubmitChanges();

            var m2 = from emr in employees select new { Name = emr.Name, Id = emr.Id};
            DropDownList1.DataSource = m2;  // Set data source
            DropDownList1.DataTextField = "Name";  // Display Name
            DropDownList1.DataValueField = "Id";  // Use Id as value
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));


            GridView1.DataSource= employees;
            GridView1.DataBind();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox5.Text = "";
            }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataContext dataContext = new DataContext(@"data source=LAPTOP-QCUS1N83;initial catalog=Test_LINQ_TwoLayer; Integrated security=true");
            Table<Employee> employees = dataContext.GetTable<Employee>();
            Employee em=  (from emp in  employees where emp.Id==Convert.ToInt32(DropDownList1.SelectedItem.Value) select emp).Single<Employee>();
            employees.DeleteOnSubmit(em);
            dataContext.SubmitChanges();

            GridView1.DataSource = employees;
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataContext dataContext = new DataContext(@"data source=LAPTOP-QCUS1N83;initial catalog=Test_LINQ_TwoLayer; Integrated security=true");
            Table<Employee> employees = dataContext.GetTable<Employee>();
            Employee em = (from emp in employees where emp.Id == Convert.ToInt32(DropDownList1.SelectedItem.Value) select emp).Single<Employee>();
           
            em.Name=TextBox1.Text;
            em.Job=TextBox2.Text;
            em.Salary = Convert.ToInt32(TextBox3.Text);
            dataContext.SubmitChanges();
            GridView1.DataSource = employees;
            GridView1.DataBind();
        }
    }
    }