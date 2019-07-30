using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature1Steps : Utils.Start
    {
        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);
       
            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();

            
        }
        
        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys("English");

            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")).Click();

            //Choose the language level
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[1];
            Lang.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();

        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "English";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if(ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch(Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed",e.Message);
            }

             

        }

        [When(@"I add different languages '(.*)'  with levels '(.*)'")]
        public void WhenIAddDifferentLanguagesWithLevels(string p0, string p1)
        {
            int level = 0;
            switch (p1)
            {
                case "Fluent":
                    level = 1;
                    break;
                case "Native":
                    level = 2;
                    break;
                case "Conversational":
                    level = 3;
                    break;
                case "Basic":
                    level = 4;
                    break;
                default:
                    Console.WriteLine("please select a level");
                    break;
            }
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys(p0);

            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")).Click();

            //Choose the language level
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[level];
            Lang.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();

            //ScenarioContext.Current.Pending();
        }

        [When(@"I delete ""(.*)"" language")]
        public void WhenIDeleteLanguage(string p0)
        {
            string actualValue;
            int row = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody")).Count;
            IWebElement data;

            for (int i = 1; i <= row; i++)
            {
                data = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody" + "[" + i + "]" + "/tr/td[1]"));
                actualValue = data.Text;
                Console.WriteLine(data.Text);

                if (p0.Equals(actualValue))
                {
                    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody" + "[" + i + "]" + "/tr/td[3]/span[2]/i")).Click();
                    break;
                }
            }
            //ScenarioContext.Current.Pending();
        }

        [Then(@"""(.*)"" shouldnot be displayed on my listings")]
        public void ThenShouldnotBeDisplayedOnMyListings(string p0)
        {
            string actualValue;
            int row;
            IWebElement data;
            bool result = true;
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Language");

                Thread.Sleep(2000);
                //   string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                row = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody")).Count;
                Console.WriteLine(row);
                Thread.Sleep(500);
                for (int i = 1; i <= row; i++)
                {
                    data = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody" + "[" + i + "]" + "/tr/td[1]"));
                    actualValue = data.Text;
                    if (p0 != actualValue)
                    {
                        result = true;
                    }

                    else
                    {
                        result = false;
                        break;
                    }

                }
                if (result == true)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageDeleted");
                }
                else
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

            //ScenarioContext.Current.Pending();
        }


        [Then(@"First added (.*) languages '(.*)' should be displayed on my listings")]
        public void ThenFirstAddedLanguagesShouldBeDisplayedOnMyListings(int p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I clicked on the Education tab under Profile page")]
        public void GivenIClickedOnTheEducationTabUnderProfilePage()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I clicked on ""(.*)"" tab")]
        public void GivenIClickedOnTab(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I add university ""(.*)"" Degree ""(.*)""")]
        public void WhenIAddUniversityDegree(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Education with Degree ""(.*)"" should be displayed on my listings")]
        public void ThenEducationWithDegreeShouldBeDisplayedOnMyListings(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I clicked on the skills tab under Profile page")]
        public void GivenIClickedOnTheSkillsTabUnderProfilePage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I edit ""(.*)"" to ""(.*)""skill")]
        public void WhenIEditToSkill(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"""(.*)"" skill should be displayed on my listings")]
        public void ThenSkillShouldBeDisplayedOnMyListings(string p0)
        {
            ScenarioContext.Current.Pending();
        }



    }


}
