using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using TechTalk.SpecFlow.CommonModels;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class FeatureSteps
    {
        private IWebDriver driver;

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        [Given(@"open the browser")]
        public void GivenOpenTheBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Given(@"the current page is '([^']*)'")]
        public void GivenTheCurrentPageIs(string google)
        {
            driver.Url = "https://www.google.es";
            driver.FindElement(By.XPath("//*[@id='L2AGLb']/div")).Click();
        }

        [When(@"the user searches for '([^']*)'")]
        public void WhenTheUserSearchesFor(string inputString)
        {
            driver.FindElement(By.Name("q")).SendKeys(inputString);
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
            Thread.Sleep(5000);
        }

        [Then(@"the number of results is more than '([^']*)'")]
        public void ThenTheNumberOfResultsIs(string expectedNumberResults)
        {
            //Validate number of search results returned
            IWebElement searchStats = driver.FindElement(By.Id("result-stats"));

            // Get the total value from the result
            String resultString = searchStats.Text.Split(' ')[1];

            // Remove the char '.' from the string
            resultString = resultString.Replace(".", string.Empty);

            // Convert string to long
            long numberOfResults = Convert.ToInt64(resultString);
            long expectedNumberResultsLong = Convert.ToInt64(expectedNumberResults);

            Assert.IsTrue(numberOfResults > expectedNumberResultsLong, "Results are less than " + expectedNumberResults);
        }

        [Then(@"the number of results is less than '([^']*)'")]
        public void ThenTheNumberOfResultsIsLessThan(string expectedNumberResults)
        {
            //Validate number of search results returned
            IWebElement searchStats = driver.FindElement(By.Id("result-stats"));

            // Get the total value from the result
            String resultString = searchStats.Text.Split(' ')[1];

            Console.WriteLine(resultString);

            // Remove the char '.' from the string
            resultString = resultString.Replace(".", string.Empty);

            // Convert string to long
            long numberOfResults = Convert.ToInt64(resultString);
            long expectedNumberResultsLong = Convert.ToInt64(expectedNumberResults);

            Assert.IsTrue(numberOfResults < expectedNumberResultsLong, "Results are more than " + expectedNumberResults);
        }

        [Then(@"close browser")]
        public void ThenCloseBrowser()
        {
            driver.Close();
        }


    }
}