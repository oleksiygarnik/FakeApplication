// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var tab;
var tabContent;

window.onload = function () {
    tabContent = document.getElementsByClassName('tabContent');
    tab = document.getElementsByClassName('tab');
    hideTabsContent(1);
}

function hideTabsContent(a) {
    for (var i = a; i < tabContent.length; i++) {
        tabContent[i].classList.remove('show');
        tabContent[i].classList.add('hide');
        tab[i].classList.remove('whiteboarder');
    }
}

document.getElementById('tabs').onclick = function (event) {
    var target = event.target;
    if (target.className == 'tab') {
        for (var i = 0; i < tab.length; i++) {
            if (target == tab[i]) {
                showTabsContent(i);
                break;
            }
        }
    }
}

function showTabsContent(b) {
    if (tabContent[b].classList.contains('hide')) {
        hideTabsContent(0);
        tab[b].classList.add('whiteboarder');
        tabContent[b].classList.remove('hide');
        tabContent[b].classList.add('show');
    }
}



$(function () {
    'use strict';


    $('a[href^="#"]').click(function () {
        let target = $(this).attr('href');
        $('html, body').animate(
            {
                scrollTop: $(target).offset().top
            },
            800
        );
    });

    var offset = $('#bottom_header').offset();

    $(window).scroll(function () {
        if ($(window).scrollTop() > offset.top) {
            $('#bottom_header').addClass('fix');
        }
        else {
            $('#bottom_header').removeClass('fix');
        }
    });



    if (window.innerWidth > 1024) {
        $('#slide').slick(
            {
                slidesToShow: 3,
                slideToScroll: 1,
                autoplay: true,
                autoplaySpeed: 1000,
            });
    }
    else {
        $('#slide').slick(
            {
                slidesToShow: 1,
                slideToScroll: 1,
                autoplay: true,
                autoplaySpeed: 1000,
            });
    }


    $('#view_all_gallery').click(function () {
        let content = '<div class="gallery_line main_flex__nowrap flex__jcontent_between"><div class="box_img_gallery" ><img src="../img/images/Layer1.png" alt="" id="myImg7"/></div ><div class="box_img_gallery"><img src="../img/images/Layer2.png" alt="" id = "myImg8"/></div> </div ><div class="name_gallery">Marina Palms / <span class="blue">North Miami Beach, FL 33162</span></div>';
      
        $('#gallery_box').append(content);
        $(this).remove();
    });


    //$('#modal_box, #black_fill').hide();

    //$('#modal_box_signin').hide();

    //$('#call').click(function() {
    //    $('#modal_box, #black_fill').show();
    //});

    //$('#signin').click(function () {
    //    $('#modal_box_signin, #black_fill').show();
    //});



    //$('#close_modal, #black_fill, #close_modal_signin').click(function () {
    //    $('#modal_box, #black_fill, #modal_box_signin').hide();
    //});


    $('#cart, .title_cart, .paymentsMove').click(function () {
        $('#cart_box').toggleClass('open');
    });

    $('#replenish').click(function () {

        showTabsContent(0);
    });

    $('#withdraw').click(function () {

        showTabsContent(1);
    });

    $('#transfer').click(function () {

        showTabsContent(2);
    });


    $('#signin').click(function () {
        $('#black_fill').toggleClass('open');
        $('#modal_box_signin').toggleClass('open');
    });

    $('#close_modal_signin, #black_fill').click(function () {
        $('#black_fill').toggleClass('open');
        $('#modal_box_signin').toggleClass('open');
    });


    $('#signup').click(function () {
        $('#black_fill').toggleClass('open');
        $('#modal_box_signup').toggleClass('open');
    });

    $('#close_modal_signup, #black_fill').click(function () {
        $('#black_fill').toggleClass('open');
        $('#modal_box_signup').toggleClass('open');
    });
});




$(window).on('load', function () {
    var $preloader = $('#p_prldr'),
        $svg_anm   = $preloader.find('.svg_anm');
    $svg_anm.fadeOut();
    $preloader.delay(500).fadeOut('slow');
});

var modal = document.getElementById('myModal');
var img1 = document.getElementById('myImg1');
var img2 = document.getElementById('myImg2');
var img3 = document.getElementById('myImg3');
var img4 = document.getElementById('myImg4');
var img5 = document.getElementById('myImg5');
var img6 = document.getElementById('myImg6');
var img7 = document.getElementById('myImg7');
var img8 = document.getElementById('myImg8');



var modalImg = document.getElementById('img01');
var captionText = document.getElementById("caption");

img1.onclick = function () {
    modal.style.display = "block";
    modalImg.src = this.src;
    captionText.innerHTML = this.alt;
}

img2.onclick = function () {
    modal.style.display = "block";
    modalImg.src = this.src;
    captionText.innerHTML = this.alt;
}

img3.onclick = function () {
    modal.style.display = "block";
    modalImg.src = this.src;
    captionText.innerHTML = this.alt;
}

img4.onclick = function () {
    modal.style.display = "block";
    modalImg.src = this.src;
    captionText.innerHTML = this.alt;
}

img5.onclick = function () {
    modal.style.display = "block";
    modalImg.src = this.src;
    captionText.innerHTML = this.alt;
}

img6.onclick = function () {
    modal.style.display = "block";
    modalImg.src = this.src;
    captionText.innerHTML = this.alt;
}
img7.onclick = function () {
    modal.style.display = "block";
    modalImg.src = this.src;
    captionText.innerHTML = this.alt;
}
img8.onclick = function () {
    modal.style.display = "block";
    modalImg.src = this.src;
    captionText.innerHTML = this.alt;
}


var span = document.getElementsByClassName("close")[0];

span.onclick = function () {
    modal.style.display = "none";
}


