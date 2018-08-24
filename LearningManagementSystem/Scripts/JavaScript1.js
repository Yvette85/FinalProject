$(document).ready(function () {
   
 
    $("#End_Date").on("change", OnChange);
    $("#Start_Date").on("change", OnChange);
    

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
    

}

