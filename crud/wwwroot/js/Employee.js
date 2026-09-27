$(document).ready(function(){
    $("#EmployeeForm").validate({
        rules : {
             Name: {
                required: true
            },
            Email:{
                required : true,
                email :true
            },
            Phone:{
                required:true,
                 minlength: 10,
                maxlength: 10,
                digits: true
            },
             Salary: {
                required: true,
                number: true
            },
            Gender: {
                required: true
            },

            Description: {
                required: true,
                minlength: 5
            },

            DepartmentId: {
                required: true
            }
        },
        messages:{
             Name: {
                    required: "Please enter name."
                },
                Email:
                {
                     required: "Please enter email.",
                        email: "Please enter a valid email."
                },
                Phone: {
                    required: "Please enter phone number.",
                    minlength: "Phone number must be 10 digits.",
                    maxlength: "Phone number must be 10 digits.",
                    digits: "Please enter only digits."
                },
                  Salary: {
                        required: "Please enter salary.",
                        number: "Please enter a valid salary."
                    },
                   Gender: {
                required: "Please select gender."
            },

            Description: {
                required: "Please enter description.",
                minlength: "Description must be at least 5 characters."
            },

            DepartmentId: {
                required: "Please select department."
            }

        },
        errorElement:"div",
        errorPlacement:function(error,element)
        {
            error.addClass("invalid-feedback");
            error.insertAfter(element);
        },
        submitHandler:function(form){
            SaveEmployee();
        }
    })
});


function SaveEmployee() {
    var employee = {
        Id: $("#Id").val(),
        Name: $("#Name").val(),
        Email: $("#Email").val(),
        Phone: $("#Phone").val(),
        Salary: $("#Salary").val(),
        Gender: $('input[name="Gender"]:checked').val(),
        Description: $("#Description").val(),
        DepartmentId: $("#DepartmentId").val(),
        IsActive: $("#IsActive").is(":checked")
    };

    $.ajax({
        url:"/Employee/Save",
        type: "POST",
        data :employee,
        success:function(response)
        {
            if(response.success)
            {
                alert(response.message);
                window.location.href="/Employee";
            }
            else{
                alert(response.message);
            }
        }
    })
}

function DeleteEmployee(employeeId)
{
    var result = confirm("Are you sure you want to delete?");

    if(result)
    {
        $.ajax({
            url:"/Employee/Delete",
            type: "POST",
            data:{EmployeeId : employeeId},
            success : function (response)
            {
                if(response.success)
                {
                    alert(response.message);
                    window.location.reload();
                }
                else{
                    alert(response.message);
                }
            }
        });

    }
}