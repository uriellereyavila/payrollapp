$(document).ready(function () {
    const employee = new Employee();
    employee.InitializeEvents();
})

function Employee() {
    var site = this;
    this.requestTimeout; // request timeout delay for post
    this.employeeType; //globalize employee type for calling GetemployeeInfo request

    this.InitializeEvents = () => {
        $('#btnAddEmployee').off().click(() => {
            $('#mdlAddEmployee').modal('show');
            $('#txtName').val('');
            $('#txtTIN').val('');
        })

        $('tr.rwViewEmployeeDetails').off().click((e) => {
            var employeeDetails = e.currentTarget.children

            var name = employeeDetails[0].textContent
            var birthdate = employeeDetails[1].textContent.toString("DD-MM-YYYY")
            var TIN = employeeDetails[2].textContent
            site.employeeType = employeeDetails[3].textContent

            $('#lblName').text(name)
            $('#lblBirthdate').text(birthdate)
            $('#lblTIN').text(TIN)
            $('#lblEmployeeType').text(site.employeeType)
            $('#lblTotalDays').text(`${site.employeeType === "Regular" ? "Absences" : "Rendered Days"} (Press Enter)`)
            $('#lblTotalSalary').html(`Employee's Total Salary is <b>₱0.00<b>`)
            $('#txtTotalDays').val('')
            site.HideRequestIndicator();

            $('#mdlViewEmployee').modal('show');
        })

        $('input#txtTotalDays').change(() => {
            var totalSalary = 0;
            var totalDays = $('#txtTotalDays').val() === "" ? null : +$('#txtTotalDays').val()
            //converts given value into php currency
            var formatter = new Intl.NumberFormat('fil-PH', {
                style: 'currency',
                currency: 'PHP',
            });

            clearTimeout(site.setTimeout);
            site.SetRequestIndicator(1, "Please wait...")
            site.ShowRequestIndicator();

            site.setTimeout = setTimeout(async () => {
                if (!isNaN(totalDays) && totalDays !== null) { /// check if it is NaN (Not a Number)
                    if (site.employeeType === "Regular") {
                        await site.GetRegularEmployeeInfo().then(res => {
                            site.HideRequestIndicator()

                            totalSalary = res.EmpRegularInfo.Salary
                        }).catch(err => {
                            site.SetRequestIndicator(0, err)
                        })
                    } else {
                        await site.GetContrauctualEmployeeInfo().then(res => {
                            site.HideRequestIndicator();
                            totalSalary = res.EmpContractualInfo.Salary
                        });
                    }
                    $('#lblTotalSalary').html(`Employee's Total Salary is <b>${formatter.format(totalSalary)}<b>`)
                } else {
                    site.SetRequestIndicator(0, "The data inputted is not a number.")
                    $('#lblTotalSalary').html(`Employee's Total Salary is <b>₱0.00<b>`)
                }
            }, 500);
        })
    }

    //Get Regular Emplyoee Info
    this.GetRegularEmployeeInfo = () => {
        return new Promise((resolve, reject) => {
            $.post('../Home/GetEmployeeInfo', {
                employeeModel: {
                    employeeType: site.employeeType,
                    empRegularInfo: {
                        totalAbsent: $('#txtTotalDays').val()
                    }
                }
            }, (res) => {
                var response = JSON.parse(res)

                if (response.Status === 1) {
                    resolve(response.Data)
                } else {
                    reject(response.Message)
                }
            }).fail((ex) => {
                reject(ex.statusText)
            })
        })

    }

    //Get Regular Emplyoee Info
    this.GetContrauctualEmployeeInfo = async () => {
        return new Promise((resolve, reject) => {
            $.post('../Home/GetEmployeeInfo', {
                employeeModel: {
                    employeeType: site.employeeType,
                    empContractualInfo: {
                        renderedDays: $('#txtTotalDays').val()
                    }
                }
            }, (res) => {
                var response = JSON.parse(res)

                if (response.Status === 1) {
                    resolve(response.Data)
                } else {
                    reject(response.Message)
                }
            }).fail((ex) => {
                reject(ex.statusText)
            })
        })
    }

    //Show Request Validator
    this.ShowRequestIndicator = () => {
        $('#lblRequestIndicator').css('visibility', 'visible');
    }

    //Hide Request Validator
    this.HideRequestIndicator = () => {
        $('#lblRequestIndicator').css('visibility', 'collapse');
    }

    this.SetRequestIndicator = (status, message) => {
        $('#lblRequestIndicator').text(message)

        if (status === 1) {
            $('#lblRequestIndicator').removeClass('text-danger')
            $('#lblRequestIndicator').addClass('text-secondary')
            
        } else {
            $('#lblRequestIndicator').removeClass('text-secondary')
            $('#lblRequestIndicator').addClass('text-danger')
        }
    }
}