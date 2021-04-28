$(document).ready(function () {
    const employee = new Employee();
    employee.InitializeEvents();
})

function Employee() {
    var site = this;

    this.InitializeEvents = () => {
        $('#btnAddEmployee').off().click(() => {
            $('#mdlAddEmployee').modal('show');
            $('#txtName').val('');
            $('#txtTIN').val('');
        })

        $('tr#rwViewEmployeeDetails').off().click(function () {
            var employeeDetails = $(this).children()
            console.log(employeeDetails)
            var name = employeeDetails[0].textContent
            var birthdate = employeeDetails[1].textContent.toString("DD-MM-YYYY")
            var TIN = employeeDetails[2].textContent
            var employeeType = employeeDetails[3].textContent
            
            $('#lblName').text(name)
            $('#lblBirthdate').text(birthdate)
            $('#lblTIN').text(TIN)
            $('#lblEmployeeType').text(employeeType)

            $('#mdlViewEmployee').modal('show');
        })
    }

    this.GetFormattedDate = (date) => {
        var todayTime = new Date(date);
        var month = format(todayTime.getMonth() + 1);
        var day = format(todayTime.getDate());
        var year = format(todayTime.getFullYear());
        return month + "/" + day + "/" + year;
    }
}