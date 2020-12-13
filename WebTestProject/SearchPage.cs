using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;


namespace WebTestProject.PageObjects
{
    public class SearchPage
    {
        public IWebDriver Driver;

        /// <summary>
        /// This section groups all the objects on the web page 
        /// </summary>

        //button Accept Cookies
        IWebElement BtnAcceptCookies => Driver.FindElement(By.ClassName("cookie-popup-with-overlay__button"));

        //Fields to select Depart, Destination, Dates
        IWebElement TxtBoxDeparture => Driver.FindElement(By.Id("input-button__departure"));
        IWebElement TxtBoxDestination => Driver.FindElement(By.Id("input-button__destination"));
        ReadOnlyCollection<IWebElement> ListMonths => Driver.FindElements(By.ClassName("m-toggle__month"));
        IWebElement CalendarDays => Driver.FindElement(By.XPath("//calendar[@Class='datepicker__calendar datepicker__calendar--left']"));
        IWebElement TitleMonth => CalendarDays.FindElement(By.XPath("//div[@Class='calendar__month-name']"));
        IWebElement ArrowNextMonths => Driver.FindElement(By.XPath("//div[@data-ref='calendar-btn-next-month']"));
        IWebElement AdultNumber => Driver.FindElement(By.XPath("//ry-counter[@data-ref='passengers-picker__adults']//div[@data-ref='counter.counter__value']"));
        IWebElement AdultAdd => Driver.FindElement(By.XPath("//ry-counter[@data-ref='passengers-picker__adults']//div[@data-ref='counter.counter__increment']"));
        IWebElement ChildNumber => Driver.FindElement(By.XPath("//ry-counter[@data-ref='passengers-picker__children']//div[@data-ref='counter.counter__value']"));
        IWebElement ChildAdd => Driver.FindElement(By.XPath("//ry-counter[@data-ref='passengers-picker__children']//div[@data-ref='counter.counter__increment']"));
        IWebElement BtnSearch => Driver.FindElement(By.CssSelector("Button[aria-label='Search']"));

        //Objects to change the dates and select the fare value
        ReadOnlyCollection<IWebElement> BtnNextDatesArrow => Driver.FindElements(By.CssSelector("Button[aria-label='Search next dates']"));
        ReadOnlyCollection<IWebElement> ListDates => Driver.FindElements(By.XPath("//div[@class='carousel']"));
        ReadOnlyCollection<IWebElement> DepartFlightCards => Driver.FindElements(By.XPath("//flight-card"));
        ReadOnlyCollection<IWebElement> Fare_value => Driver.FindElements(By.XPath("//fare-card//div//div//button"));

        //Objects to select the names and seats
        IWebElement BtnLogInLater => Driver.FindElement(By.CssSelector("Button[class='login-touchpoint__expansion-bar']"));
        ReadOnlyCollection<IWebElement> PassengersTitleDropBox => Driver.FindElements(By.XPath("//pax-passenger-container//div[@class='dropdown b2']"));
        ReadOnlyCollection<IWebElement> PassengersTitles => Driver.FindElements(By.XPath("//ry-dropdown-item"));
        ReadOnlyCollection<IWebElement> PassengersNames => Driver.FindElements(By.XPath("//input[@class='b2 date-placeholder']"));
        IWebElement ButtonPassgersNamesContinue => Driver.FindElement(By.XPath("//button[@class='continue-flow__button ry-button--gradient-yellow']"));
        IWebElement ButtonFamilySeating => Driver.FindElement(By.XPath("//Button[@class='seats-modal__cta ry-button--gradient-blue']"));
        ReadOnlyCollection<IWebElement> PassengersSeats => Driver.FindElements(By.XPath("//div[@data-ref='seat-map__seat-row-19']//Button"));
        IWebElement ButtonNextFlight => Driver.FindElement(By.XPath("//Button[@data-ref='seats-action__button-next']"));
        IWebElement ButtonContinueSeatsFlight => Driver.FindElement(By.XPath("//Button[@data-ref='seats-action__button-continue']"));
        IWebElement ButtonNoThanks => Driver.FindElement(By.XPath("//Button[@data-ref='enhanced-takeover-beta-desktop__dismiss-cta']"));
        IWebElement RadioBtnSmallBag => Driver.FindElement(By.XPath("//ry-radio-circle-button[@class='ng-star-inserted']"));
        IWebElement ButtonContinueBags => Driver.FindElement(By.XPath("//Button[@class='ry-button--gradient-yellow']"));
        IWebElement ButtonContinueExtras => Driver.FindElement(By.XPath("//Button[@class='ry-button--full ng-tns-c167-1 ry-button--gradient-yellow ry-button--large']"));
        
        /// <summary>
        /// This section brings the methods to resolve each step.
        /// </summary>

        
        public void Go_To_Url(string Url)
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(Url);
        }

        public void Click_Accept_Cookies()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement webElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(BtnAcceptCookies));
            webElement.Click();
        }

        public void Select_Departure(String Departure)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement webElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(TxtBoxDeparture));
            webElement.Clear();
            Thread.Sleep(1000);
            webElement.Clear();
            webElement.SendKeys(Departure);
        }

        public void Select_Destination(String Destination)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement webElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(TxtBoxDestination));
            webElement.Click();
            Thread.Sleep(1000);
            webElement.SendKeys(Destination);
            webElement.SendKeys(Keys.Tab);
        }

        public void Select_Departure_Date(string MonthDep, string DayDep)
        {
            Thread.Sleep(1000);
            foreach (IWebElement Month in ListMonths)
            {
                if (Month.Text == MonthDep)
                {
                    Month.Click();
                    Thread.Sleep(1000);
                    IWebElement ListDepartDays = CalendarDays.FindElement(By.XPath("//div[@data-value='"+ DayDep +"']"));
                    ListDepartDays.Click();
                    Thread.Sleep(1000);
                    break;
                }
            }
        }

        public void Select_Arrived_Date(string MonthDest, string DayDest)
        {
            while(TitleMonth.Text != MonthDest)
            {
                ArrowNextMonths.Click();
            }
            IWebElement ListDepartDays = CalendarDays.FindElement(By.XPath("//div[@data-value='" + DayDest + "']"));
            ListDepartDays.Click();
           
        }

        public void Select_Adult_Cant(string AdultCant)
        {
            Thread.Sleep(1000);
            
            while (AdultNumber.Text != AdultCant)
            {
                AdultAdd.Click();
            }
        }

        public void Select_Child_Cant(string ChildCant)
        {
            Thread.Sleep(1000);
            while (ChildNumber.Text != ChildCant)
            {
                ChildAdd.Click();
            }
        }

        public void Click_Search()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement webElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(BtnSearch));
            webElement.Click();
        }

        public void Update_Depart_Date(string NewDepartDate)
        {
            Thread.Sleep(3000);
            bool found = false;
            ReadOnlyCollection<IWebElement> DatesDepart = ListDates[0].FindElements(By.TagName("li"));
            foreach (IWebElement Date in DatesDepart)
            {
                Thread.Sleep(1000);
                IWebElement element = Date.FindElement(By.TagName("Button"));
                if (element.GetAttribute("data-ref") == NewDepartDate)
                {
                    Thread.Sleep(3000);
                    Date.Click();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                BtnNextDatesArrow[0].Click();
                Update_Depart_Date(NewDepartDate);
            }

        }

        public void Select_New_Depart_Date()
        {
            Thread.Sleep(1000);
            DepartFlightCards[0].Click();
        }

        public void Select_Fare_value()
        {
            Thread.Sleep(3000);
            foreach (IWebElement fare in Fare_value)
            {
                if (fare.Text == "Continue with Value fare")
                {
                    Thread.Sleep(1000);
                    fare.Click();
                    break;
                }
            }
        }

        public void Update_Destination_Date(string NewArriveDate)
        {
            Thread.Sleep(3000);
            bool found = false;
            ReadOnlyCollection<IWebElement> DatesDepart = ListDates[1].FindElements(By.TagName("li"));
            foreach (IWebElement Date in DatesDepart)
            {
                Thread.Sleep(1000);
                IWebElement element = Date.FindElement(By.TagName("Button"));
                if (element.GetAttribute("data-ref") == NewArriveDate)
                {
                    Thread.Sleep(1000);
                    Date.Click();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                BtnNextDatesArrow[1].Click();
                Update_Destination_Date(NewArriveDate);
            }
        }

        public void Select_New_Arrived_Date()
        {
            Thread.Sleep(3000);
            DepartFlightCards[1].Click();
        }

        public void Click_Log_in_Later()
        {
            Thread.Sleep(3000);
            BtnLogInLater.Click();
        }

        public void Fill_the_passengers_Information()
        {
            Thread.Sleep(3000);
            List<string> names = new List<string>
            {
                "Sónia", "Pereirao", "Diogo", "Bettencourto", "Inês", "Marçal"
            };
            int count = 0;
            foreach(IWebElement Name in PassengersNames)
            {
                if (count == 0)
                {
                    PassengersTitleDropBox[0].Click();
                    PassengersTitles[1].Click();
                }
                if (count == 2)
                {
                    PassengersTitleDropBox[1].Click();
                    PassengersTitles[1].Click();
                }
                Name.SendKeys(names[count]);
                if (count == 5)
                    break;
                count++;
            }

        }

        public void Click_Continue_Button()
        {
            Thread.Sleep(3000);
            ButtonPassgersNamesContinue.Click();
        }
        public void Click_Okay_Message()
        {
            Thread.Sleep(5000);
            ButtonFamilySeating.Click();
        }
        
        public void Select_First_Flight_Seats()
        {
            for(int i = 0; i < 3 ; i++)
            {
                Thread.Sleep(3000);
                PassengersSeats[i].Click();
            }
            
        }
        public void Click_Next_Flight_Button()
        {
            Thread.Sleep(3000);
            ButtonNextFlight.Click();
        }

        public void Select_Second_Flight_Seats()
        {
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(3000);
                PassengersSeats[i].Click();
            }

        }
        public void Click_Continue_Button_Seats()
        {
            Thread.Sleep(3000);
            ButtonContinueSeatsFlight.Click();
        }

        public void Click_No_Thanks_Button()
        {
            Thread.Sleep(3000);
            ButtonNoThanks.Click();
        }

        public void Select_Small_Bag()
        {
            Thread.Sleep(5000);
            RadioBtnSmallBag.Click();
        }

        public void Click_Continue_Button_Bags()
        {
            Thread.Sleep(3000);
            ButtonContinueBags.Click();
        }

        public void Click_Continue_Button_Extras()
        {
            Thread.Sleep(3000);
            ButtonContinueExtras.Click();
        }

    }
}
