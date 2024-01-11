using FluentAssertions;
using SpecFlowPlaywright.Drivers;
using SpecFlowPlaywright.Pages;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowPlaywright.Steps;

[Binding]
public sealed class EAAppTestSteps
{
    private readonly Driver _driver;
    private readonly LoginPage _loginPage;

    public EAAppTestSteps(Driver driver)
    {
        _driver = driver;
        _loginPage = new LoginPage(_driver.Page);
    }


    [Given(@"I enter following login details")]
    public async Task GivenIEnterFollowingLoginDetails(Table table)
    {
        dynamic data = table.CreateDynamicInstance();
        await _loginPage.Login((string)data.UserName, (string)data.Password);
    }

    [Given(@"I navigate to appliacation")]
    public void GivenINavigateToAppliacation()
    {
        _driver.Page.GotoAsync("http://www.eaapp.somee.com");
    }

    [Given(@"I click login link")]
    public async Task GivenIClickLoginLink()
    {
        await _loginPage.ClickLogin();
    }

    [Then(@"I see Employee Lists")]
    public async Task ThenISeeEmployeeLists()
    {
        var isExist = await _loginPage.IsEmployeeDetailsExists();
        isExist.Should().Be(true);
    }
}