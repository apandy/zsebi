(function () {

    function initCharacterCounter() {
        $("[data-ch-count-for]").each(function () {
            var $view = $(this);
            var maxChar = parseInt($view.text());
            var $target = $($view.data("chCountFor"));

            function setLength() {
                var content = $target.val();
                var currentLength = (content || "").length;
                $view.text(maxChar - currentLength);
            }

            $target.on("change", setLength);
            $target.on("keyup", setLength);
            setLength();
        });
    }

    function initAutoGenerateUrl() {
        $("#generate-url").each(function() {
            var $autoGenerateUrl = $(this);
            var $title = $("#Title");
            var $url = $("#Url");

            function createUrl() {
                if ($autoGenerateUrl.prop('checked')) {
                    var title = $title.val() || "";
                    var url = convertToUrl(title);
                    $url.val(url);
                }
            }

            $title.on("keyup", createUrl);
            $title.on("change", createUrl);
            $autoGenerateUrl.on("change", createUrl);
        });
    }

    $(function () {
        initCharacterCounter();
        initAutoGenerateUrl();
    });

})();
