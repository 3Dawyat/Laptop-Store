let arrItem = [];
let ClsItems = {
    LoadItems: function () {
        Helper.AjaxCallGet("/api/ItemsApi",{}, "json", function (data) {
            arrItem = data;
            console.log(data);
            let htmlData="";
            for (let i = 0; i < data.length; i++) {
                htmlData += ClsItems.temp1(data[i]);
            }
            $("#templet1").html(htmlData);
        },
            function () {
            });
    },
    FilterItems2: function (ctId) {
        let Filter = $.grep(arrItem, function (n, i) {
            return n.categoryId === ctId;
        });
        let htmlData = "";
        for (let i = 0; i < Filter.length; i++) {
            htmlData += ClsItems.temp2(Filter[i]);
        }
        $("#secItems").html(htmlData);
    },
    temp2: function (item) {
        let productHtml = "<article><div><div class='col-lg-12'>" ;
        productHtml += "<div class='row'><div class='left-list col-lg-12'>";
        productHtml += "<div class='col-lg-12'><div class='tab-item'>";
        productHtml += "<img src='/Uplude/" + item.imageName +"' alt=''>";
        productHtml += "<h4>" + item.itemName+"</h4>";
        productHtml += "<div class='price'><h6>" + item.salesPrice+"</h6></div>";
        productHtml += "</div></div></div></div></div></div></article>";
        return productHtml;
        
    },

}

ClsItems.LoadItems();