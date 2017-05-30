/* Code JS gọi PopupWindow thông qua modal placeholder ở dưới  */
/* placeholder sẽ được đặt trong View mà muốn hiển thị các popup lên trên View đó */

//Link TUT:
//http://www.advancesharp.com/blog/1125/search-sort-paging-insert-update-and-delete-with-asp-net-mvc-and-bootstrap-modal-popup-part-1
//http://www.advancesharp.com/blog/1126/search-sort-paging-insert-update-and-delete-with-asp-net-mvc-and-bootstrap-modal-popup-part-2


//<!-- modal placeholder-->
//<div id='myModal' class='modal fade in'>
//    <div class="modal-dialog">
//        <div class="modal-content">
//            <div id='myModalContent'></div>
//        </div>
//    </div>
//</div>


$(function () {
    $.ajaxSetup({ cache: false });
    $("a[data-url]").on("click", function (e) {
        $('#myModalContent').load(this.href, function () {
            $('#myModal').modal({
                keyboard: true
            }, 'show');
            bindForm(this);
        });
        return false;
    });
});

function bindForm(dialog) {

    $('form', dialog).submit(function () {
        $('#progress').show();
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#myModal').modal('hide');
                    $('#progress').hide();
                    location.reload();
                } else {
                    $('#progress').hide();
                    $('#myModalContent').html(result);
                    bindForm();
                }
            }
        });
        return false;
    });
}