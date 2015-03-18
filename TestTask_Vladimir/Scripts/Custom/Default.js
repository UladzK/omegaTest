//javascript Default class for default.aspx page
function Default() {

    self = this;

    var langBoxContent;
    var langBoxHeight;

    function onLangIdentify(result, context) {
        context.title = result;
    }

    function onError() {}

    this.init = function () {

        $('body').on('mouseenter',
                     '.singleWord',                    
                    function () {
                        //if title is empty:
                        //because if NOT empty so language already detected and have no need to check it again
                        if (this.title.isEmpty) {
                            var word = this.textContent;

                            //identify only words with length >=4
                            if (word.length < 4) {
                                return "";
                            }
                            //calling server-side code behind
                            PageMethods.LangIdentify(word, onLangIdentify, onError, this);
                        }
                    });

        //makes textarea auto-resizable
//        $('body').on('keyup',
//                    '.langBox',
//                    function () {
//                        while ($(this).outerHeight() < this.scrollHeight +
//                            parseFloat($(this).css("borderTopWidth")) +
//                            parseFloat($(this).css("borderBottomWidth"))) {
//                            $(this).height($(this).height() + 1);
//                            $(this).minHeight = $(this).height;
//                        }
//                    });

        $('body').on('mouseout',
                    '.langBox',
                    function() {
                        langBoxContent = $('.langBox').val();
                        langBoxHeight = $('.langBox').height();

                        $('.wordsContainer').children().remove();
                        $('.wordsContainer').height(langBoxHeight + 25);
                        
                        commas = langBoxContent.match(/([\s*,.?!:;\s*]+)/gi);
                        var words = langBoxContent.split(/[\s,.!?:;]+/);

                        if (commas == null) {
                            commas = [];
                        }
                        commas.push("");

                        var i = 0;
                        $('.wordsContainer').append("<pre class='pre-formatted'>");
                        words.forEach(function(element) {                            
                            $('.pre-formatted').append("<span class='singleWord' title=''>" + element + "</span>");
                            $('.pre-formatted').append("<span class='comma'>" + commas[i] + "</span>");
                            i += 1;
                        });
                    });           

        $('.wordsContainer').click(function () {
            if ($('.wordsContainer :input').length == 0 ) {
                $('.wordsContainer').children().remove();
                $('.wordsContainer').append("<textarea id='wordsArea' rows='5' cols='3' class='langBox'></textarea>");
                $('.wordsContainer').css("height", "100%");

                $('.langBox').val(langBoxContent);
                $('.langBox').css("height", langBoxHeight);
                $('.langBox').css("visibility", "visible");
                $('.langBox').focus();
            }
        });
    }

    //isEmpty helper for simple using
    String.prototype.isEmpty = function () {
        return (this.length === 0 || !this.trim());
    };
}

var defaultObject = null;

$(document).ready(function () {

    defaultObject = new Default();
    
    defaultObject.init();
})