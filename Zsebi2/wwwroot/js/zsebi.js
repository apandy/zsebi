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
        $('.modal').modal({
            show: false
        });
        $('a.popup').on('click', function (e) {
            e.preventDefault();
            openModal($(this).attr('href'));
            
        });
    }

    function openModal(link) {
        $('.modal .modal-content')
            .load(link, function () {
                $('.modal').modal('show');
            });
    }
    $(function() {
        attachAjaxCalls();
        attachPopups();
    });

})();