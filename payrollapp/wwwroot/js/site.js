$(document).ready(function () {
    const employee = new Employee();
    employee.InitializeEvents();
})

function Employee() {

    this.InitializeEvents = () => {
        $('#btnAddEmployee').off().click(() => {
            $('#mdlAddEmployee').modal('show');
        })

        $('#frmAddEmployee').submit((e) => {
            console.log(e);
            e.preventDefault();
        })
    }
}