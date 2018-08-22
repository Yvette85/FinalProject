$(document).ready(function () {
    //window.courseStartDate = document.getElementById("StartDate").value;

 
    $("#End_Date").on("change", OnChange);
    $("#Start_Date").on("change", OnChange);
    //$("#CreateButton").on("change", OnClick);
    //$("input[type='submit']").on("click", OnClick);

});
function OnChange(e) {
    var startDate = document.getElementById("Start_Date").value;
    var endDate = document.getElementById("End_Date").value;
  

    
   
    if (startDate < endDate) {
        $("#warrningText").addClass("hidden");
  

   }
    else {
        $("#warrningText").removeClass("hidden");
   }
    //if (startDate < endDate) {
    //    $("#warningText").addClass("hidden");


    //}
    //else {
    //    $("#warningText").removeClass("hidden");

    //}


}

//function OnClick(e) {
//    if (!$("#warningText").hasClass("hidden") || !$("#warningTextForCourseStartDate").hasClass("hidden")) {
//        e.preventDefault();
//    }




//}