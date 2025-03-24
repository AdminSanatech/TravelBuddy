function toggleBackToTop(){
    var scrollTop = $(window).scrollTop();
    if (scrollTop > 100) { 
        $('#back-to-top').addClass('active'); 
        $('.social').addClass('active'); 
    } else { 
        $('#back-to-top').removeClass('active'); 
        $('.social').removeClass('active'); 
    }
}
function stickyHeader(){
    let scrollPos = window.scrollY;
    if (scrollPos > 200) {
        $('.main-menu').addClass('sticky-header');
    } else {
        $('.main-menu').removeClass('sticky-header');
    }
}
$(window).on('scroll', function() {
    toggleBackToTop()
    stickyHeader();
});
$(window).resize(function() {
    stickyHeader()
});
$(document).ready(function(){
    $('.preloader').hide();
    $('#back-to-top').on('click', function(event) {
        event.preventDefault();
        $('body, html').animate({ scrollTop: 0 }, 1000);
    });
});