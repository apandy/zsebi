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

    $(function () {
        initCharacterCounter();
    });

})();
