﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace IT481_Unit2_Crooks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form1_Load() called...");
            txtMessageText.Text = "Warming up. Hang tight."; 
            try
            {
                System.Diagnostics.Debug.WriteLine("within the try");
                SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
                connection.Open();
                txtMessageText.Text = "Connection Successful! Click a button below to get started...";
                txtMessageText.ForeColor = System.Drawing.Color.Green;
                connection.Close();
            }
            catch (Exception ex)
            {
                txtMessageText.Text = "We couldn't establish connection to the database. Error: "+ ex;
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                txtMessageText.ForeColor = System.Drawing.Color.Black;
                SqlCommand command = new SqlCommand();
                SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
                connection.Open();
                txtMessageText.Text = "Let's try inserting that record.";
                command.Connection = connection;
                command.CommandText = "insert into Customers (CustomerID, CompanyName) values('" +
                txtID.Text + "','" + txtCompany.Text + "')";
                command.ExecuteNonQuery();
                txtMessageText.Text = "That record has been successfully inserted!";
                connection.Close();
                txtMessageText.ForeColor = System.Drawing.Color.Green;
            }

            catch
            {
                txtMessageText.Text = "I couldn't do that. There was something wrong with your SQL insertion.";
                txtMessageText.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            txtMessageText.ForeColor = System.Drawing.Color.Black;
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            txtMessageText.Text = "I'm counting the records now.";
            command.Connection = connection;
            command.CommandText = "select count(*) from Customers";
            int count = (int)command.ExecuteScalar();
            txtMessageText.Text = "We currently have " + count + " records.";
            connection.Close();
            txtMessageText.ForeColor = System.Drawing.Color.Green;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            txtMessageText.ForeColor = System.Drawing.Color.Black;
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            txtMessageText.Text = "I'm gathering up the records.";
            command.Connection = connection;
            command.CommandText = "select * from Customers";
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            txtMessageText.Text = "All records from the Customers table are successfully retrieved!";
            txtMessageText.ForeColor = System.Drawing.Color.Green;
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMessageText.ForeColor = System.Drawing.Color.Black;
                SqlCommand command = new SqlCommand();
                SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
                connection.Open();
                txtMessageText.Text = "I'll try deleting that record now.";
                command.Connection = connection;
                command.CommandText = "delete from Customers where CustomerID='" + txtID.Text + "'";
                command.ExecuteNonQuery();
                txtMessageText.Text = "Record successfully deleted!";
                connection.Close();
                txtMessageText.ForeColor = System.Drawing.Color.Green;
            }

            catch
            {
                txtMessageText.Text = "I couldn't do that. There was something wrong with your SQL deletion.";
                txtMessageText.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
