(function (app) {
    app.service('ExcelService', function () {
        this.exportToExcel = function (data, fileName) {
            var wb = XLSX.utils.book_new();
            var ws = XLSX.utils.json_to_sheet(data);

            // Thêm màu cho header
            var headerStyle = {
                font: { bold: true },
                fill: { fgColor: { rgb: "FF6C909D" } } // Màu xám nhạt
            };
            ws['!cols'] = [{ width: 20 }]; // Cài đặt chiều rộng của cột (tùy chỉnh)


            //XLSX.utils.sheet_set_range_style(ws, "A1:B1", headerStyle);
            XLSX.utils.book_append_sheet(wb, ws, fileName);
            XLSX.writeFile(wb, fileName + ".xlsx");
        }
    });
})(angular.module('ShopEva.Common'));