
let ClsCategory = {
    LoadCategory: function () {
        Helper.AjaxCallGet("/api/CategoryApi", {}, "json", function (data) {
            let htmlData = "";
            for (let i = 0; i < data.length; i++) {
                htmlData += ClsCategory.temp1(data[i]);
            }
            $("#Categores").html(htmlData);
        },
            function () {

            });
    },
    temp1: function (Categ) {
        let catHtml = "<li><a href='#Category'onclick='ClsItems.FilterItems2(" + Categ.categoryId + ")'>" + Categ.categoryName + "</a></li>";
        
        return catHtml;
    },

    LoadCategory2: function () {
        Helper.AjaxCallGet("/api/CategoryApi", {}, "json", function (data) {
            let htmlDataa = "";
            for (let i = 0; i < data.length; i++) {
                htmlDataa += ClsCategory.temp2(data[i]);
            }
            $("#Category").html(htmlDataa);
        },
            function () {
            });
    },
    temp2: function (category) {
        let categHtml = "<li><a style='cursor: pointer;'   onclick='ClsItems.FilterItems2(" + category.categoryId + ")'><img style='width: 90px; height: 50px;' src='/assets/images/logo.png'>"+ category.categoryName + "</a></li>";
        return categHtml;
        console.log(category.categoryId);
    }

}
ClsCategory.LoadCategory2();
ClsCategory.LoadCategory();