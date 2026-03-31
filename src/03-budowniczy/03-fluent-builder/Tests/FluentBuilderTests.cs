using FluentBuilder.Emails;
using FluentBuilder.Employees;
using Xunit;

namespace Examples.Tests;

public class EmployeeBuilderTests
{
    [Fact]
    public void Build_DefaultValues_ReturnsEmployee()
    {
        var employee = new Employee.Builder().Build();

        Assert.Equal("Imię", employee.FirstName);
        Assert.Equal("Nazwisko", employee.LastName);
        Assert.Equal("Niezdefiniowany", employee.Department);
    }

    [Fact]
    public void Build_WithAllFields_SetsCorrectly()
    {
        var employee = new Employee.Builder()
            .WithFirstName("Anna")
            .WithLastName("Kowalska")
            .WithBirthDate(1992, 5, 14)
            .WithDepartment("Engineering")
            .WithSalary(12_500m)
            .Build();

        Assert.Equal("Anna", employee.FirstName);
        Assert.Equal("Kowalska", employee.LastName);
        Assert.Equal("Engineering", employee.Department);
        Assert.Equal(12_500m, employee.Salary);
    }

    [Fact]
    public void GetFullName_ReturnsCombination()
    {
        var employee = new Employee.Builder()
            .WithFirstName("Jan")
            .WithLastName("Nowak")
            .Build();

        Assert.Equal("Jan Nowak", employee.GetFullName());
    }

    [Fact]
    public void WithBirthDate_FutureDate_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            new Employee.Builder().WithBirthDate(2099, 1, 1).Build());
    }

    [Fact]
    public void WithSalary_Negative_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            new Employee.Builder().WithSalary(-100m));
    }

    [Fact]
    public void WithFirstName_Null_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new Employee.Builder().WithFirstName(null!));
    }

    [Fact]
    public void ImplicitOperator_ConvertsToEmployee()
    {
        Employee employee = new Employee.Builder()
            .WithFirstName("Piotr")
            .WithLastName("Wiśniewski");

        Assert.Equal("Piotr", employee.FirstName);
        Assert.Equal("Wiśniewski", employee.LastName);
    }
}

public class EmailBuilderTests
{
    [Fact]
    public void Build_ValidEmail_ReturnsEmail()
    {
        var email = new Email.Builder()
            .From("sender@test.pl")
            .To("recipient@test.pl")
            .WithSubject("Test Subject")
            .WithBody("Body text")
            .Build();

        Assert.Equal("sender@test.pl", email.From);
        Assert.Single(email.To);
        Assert.Equal("Test Subject", email.Subject);
    }

    [Fact]
    public void Build_MultipleRecipients_AllPresent()
    {
        var email = new Email.Builder()
            .From("sender@test.pl")
            .To("a@test.pl")
            .To("b@test.pl")
            .Cc("c@test.pl")
            .WithSubject("Test")
            .WithBody("Body")
            .Build();

        Assert.Equal(2, email.To.Count);
        Assert.Single(email.Cc);
    }

    [Fact]
    public void Build_WithAttachments_IncludesAll()
    {
        var email = new Email.Builder()
            .From("sender@test.pl")
            .To("recipient@test.pl")
            .WithSubject("Test")
            .WithBody("Body")
            .WithAttachment("file1.pdf")
            .WithAttachment("file2.docx")
            .Build();

        Assert.Equal(2, email.Attachments.Count);
    }

    [Fact]
    public void Build_AsHtml_SetsFlag()
    {
        var email = new Email.Builder()
            .From("sender@test.pl")
            .To("recipient@test.pl")
            .WithSubject("Test")
            .WithBody("<p>HTML</p>")
            .AsHtml()
            .Build();

        Assert.True(email.IsHtml);
    }

    [Fact]
    public void Build_NoFrom_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() =>
            new Email.Builder()
                .To("recipient@test.pl")
                .WithSubject("Test")
                .Build());
    }

    [Fact]
    public void Build_NoTo_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() =>
            new Email.Builder()
                .From("sender@test.pl")
                .WithSubject("Test")
                .Build());
    }

    [Fact]
    public void Build_NoSubject_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() =>
            new Email.Builder()
                .From("sender@test.pl")
                .To("recipient@test.pl")
                .Build());
    }
}
