(function () {
    //Index news section.
    function attachAjaxCalls() {
        $('#news_container').on('click', '#news-next-container a', function (e) {
            e.preventDefault();
            $('#news_container')
                .load($(this).attr('href'));
        });

        $('#news_container').on('click', '#news-prev-container a', function (e) {
            e.preventDefault();
            $('#news_container')
                .load($(this).attr('href'));
        });
    }

    function attachPopups() {
        $('a.popup').on('click', function (e) {
            e.preventDefault();
            var id = 'link-' + ($(this).index() + 1);
            $('<div/>', { 'class': 'myDlgClass', 'id': id, 'width': '30%' })
                .load($(this).attr('href'), function () {
                    $('a.closeButton').on('click', function (e) {
                        e.preventDefault();
                        $(this).closest(".myDlgClass").dialog('close');
                    });
                })
                .appendTo('body')
                .dialog()
                .position({
                    my: "center top",
                    at: "center top",
                    of: window
                });
        });
    }
    
    $(function() {
        attachAjaxCalls();
        attachPopups();
    });

})();