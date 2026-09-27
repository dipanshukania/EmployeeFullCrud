$(document).ready(function(){
    $("#DepartmentForm").validate({
        rules :{
            DepartmentName :"required"
        },
        messages :{
            DepartmentName : "Enter Department Name"
        },
        errorElement:"div",
        errorPlacement:function(error,element)
        {
            error.addClass("invalid-feedback");
            error.insertAfter(element);
        },
        submitHandler:function(form){
            SaveDepartment();
        }

    });
});

function SaveDepartment(){
    var department = {
        DepartmentId : $("#DepartmentId").val(),
        DepartmentName :  $("#DepartmentName").val()
    }
    $.ajax({
            url:"/Department/Save",
            type:"POST",
            data:department,
            success:function (response)
            {
                if(response.success)
                {
                    alert(response.message);
                    window.location.href="/Department";

                }
                else{
                    alert(response.message);
                }
            }
        });
}

function DeleteDepartment(departmentId)
{
    var result = confirm("Are you sure want to delete?");

    if(result)
    {
        $.ajax({
            url:"/Department/Delete",
            type:"POST",
            data:{DepartmentId : departmentId},
            success:function (response)
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