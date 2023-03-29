



function makeAPICall(url, paramters, returnFormat, success, falier) {
    $.ajax({
        type: "GET",
        url: url,
        data: paramters,
        contentType: "application/json; charset=utf-8",
        dateType: returnFormat,

        success: function (data) {
            success(data);
            return data;
        },
        
        error: function (xhr, status, error) {
            console.log("Error: " + error);
        }
    });
}


var ClsItems = {
    GetAll: function () {
        //console.log("hello there");
        makeAPICall(
            "https://localhost:7280/api/jobs",
            {},
            "json",
            function (data) {
                var htmlData = "";
                for (var i = 0; i < data.data.length; i++) {
                    //console.log(data.data[i].JobName);
                    //console.log(data.data[i]);
                    htmlData += this.ClsItems.DrawItem(data.data[i]);
                }
                //console.log(htmlData);
                var jobArea = document.getElementById('JobArea');
                jobArea.innerHTML = htmlData;
            },
            function () { })
    },
    DrawItem: function (item) {
        //console.log(item.JobName);

        var data = "<div class='single-job-items mb-30'>";
        data += "<div class='job-items'>";
        data += "<div class='company-img'>";
        data += "<a asp-controller='ViewJobDetail' asp-action='Details' asp-route-jobId='" + item.jobDetailId +"'>";
        data += "<img src='/Uploads/Companies/" + item.companyLogo + "' alt='' style='width:85px;height:86px'>";
        data += " </a>";
        data += "</div>";
        data += "<div class='job-tittle job-tittle2'>";
        data += "<a asp-controller='ViewJobDetail' asp-action='Details' asp-route-jobId='" + item.jobDetailId +"'>";
        data += "<h4>" + item.jobName +"</h4>";
        data += "</a>";
        data += "<ul>";
        data += "<li>" + item.companyName +"</li>";
        data += "<li><i class='fas fa-map-marker-alt'></i>" + item.companyAddress +"</li>";
        data += "<li>$" + item.minSalary + " - $" + item.maxSalary +"</li>";
        data += "</ul>";
        data += "</div>";
        data += "</div>";
        data += "<div class='items-link items-link2 f-right'>";
        data += "<a>" + item.jobTypeName +"</a>";
        data += "<span>" + item.postedDate +"</span>";
        data += "</div>";
        data += "</div>";
        return data;
    }
}

ClsItems.GetAll();
 
