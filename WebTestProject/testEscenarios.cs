using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using WebTestProject.PageObjects;
using DescriptionAttribute = NUnit.Framework.DescriptionAttribute;

namespace WebTestProject
{
    public class Tests
    {
        readonly SearchPage searchPage = new SearchPage();
        

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("SetUp");

            searchPage.Driver = new ChromeDriver();

        }

        [Test]
        [Description("This test case validates the booking of round trip from Lisbon to Paris Beauvais for 2 adults and 1 child.")]
        public void Find_Trip_Excercise()
        {
            //This class guides the user step by step to complete the test case clearly
            searchPage.Go_To_Url("https://www.ryanair.com/gb/en");
            searchPage.Click_Accept_Cookies();
            searchPage.Select_Departure("Lisbon");
            searchPage.Select_Destination("Paris Beauvais");
            searchPage.Select_Departure_Date("Feb", "7");
            searchPage.Select_Arrived_Date("July 2021", "25");
            searchPage.Select_Adult_Cant("2");
            searchPage.Select_Child_Cant("1");
            searchPage.Click_Search();
            searchPage.Update_Depart_Date("2021-02-19");
            searchPage.Select_New_Depart_Date();
            searchPage.Select_Fare_value();
            searchPage.Update_Destination_Date("2021-08-02");
            searchPage.Select_New_Arrived_Date();
            searchPage.Select_Fare_value();
            searchPage.Click_Log_in_Later();
            searchPage.Fill_the_passengers_Information();
            searchPage.Click_Continue_Button();
            searchPage.Click_Okay_Message();
            searchPage.Select_First_Flight_Seats();
            searchPage.Click_Next_Flight_Button();
            searchPage.Select_Second_Flight_Seats();
            searchPage.Click_Continue_Button_Seats();
            searchPage.Click_No_Thanks_Button();
            searchPage.Select_Small_Bag();
            searchPage.Click_Continue_Button_Bags();
            searchPage.Click_Continue_Button_Extras();

        }
    }
}