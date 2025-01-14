﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Encyclopedia
{
    public partial class Login : System.Web.UI.Page
    {
        static string connstring = "datasource = 127.0.0.1; port=3306;username=root;password=123456;database=encyclopedia;";
        MySqlConnection connection = new MySqlConnection(connstring);
        MySqlCommand command;
        MySqlDataReader mdr;
        protected void Page_Load(object sender, EventArgs e)
        {
            connection.Open();

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            var UserID = 0;

            if (string.IsNullOrEmpty(UserName.Text) || string.IsNullOrEmpty(LoginPassword.Text))
            {
                MessageBox.Show("Please Enter Username and Password", "Error");
            }
            else
            {
                string selectQuery = "SELECT * FROM encyclopedia.user WHERE Username = '" + UserName.Text + "' AND Password = '" + LoginPassword.Text + "';";
                command = new MySqlCommand(selectQuery, connection);
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                    Session["LoginDate"] = DateTime.Now.ToString();
                    string Query = "update encyclopedia.user set LoginDate='" + Session["LoginDate"] + "' where Username='" + UserName.Text + "';";
                    MySqlConnection MyConn2 = new MySqlConnection(connstring);

                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    mdr.Close();
                    string selectQuery2 = "SELECT UserID FROM encyclopedia.user WHERE Username = '" + UserName.Text + "' AND Password = '" + LoginPassword.Text + "';";
                    command = new MySqlCommand(selectQuery2, connection);
                    mdr = command.ExecuteReader();
                    while (mdr.Read())
                    {
                        UserID = int.Parse(mdr[0].ToString());
                    }
                    MyConn2.Close();

                    MessageBox.Show("Login Successful!");
                    Response.Redirect("Home Page.aspx?USERID=" + UserID);
                    //Response.Redirect("TourBooking.aspx?val=" + toursIDs[index] + "&userId=" + userIdentifier);
                }
                else
                {
                    mdr.Close();
                    string selectQuery1 = "SELECT * FROM encyclopedia.admin WHERE Username = '" + UserName.Text + "' AND Password = '" + LoginPassword.Text + "';";
                    command = new MySqlCommand(selectQuery1, connection);
                    mdr = command.ExecuteReader();
                    if (mdr.Read())
                    {
                        MessageBox.Show("AdminLogin Successful!");
                        Response.Redirect("Admin-Home.aspx");
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Login Information! Try again.");
                    }
                }
            }
            connection.Close();

        }

        protected void signupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");

        }

        protected void signupBtn_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }
    }
}