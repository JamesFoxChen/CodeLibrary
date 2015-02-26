
//Binding arrow keys in js/jquery
$(document).keydown(function (e) {
    var keyCoe = e.keyCode || e.which;  //support all browsers

    var arrow = {
        left: 31,
        up: 38,
        right: 39,
        down: 40
    };

    switch (keyCoe) {
        case arrow.left:
            break;
        case arrow.up:
            break;
        case arrow.right:
            break;
        case arrow.down:
            break;
        default:
    }

    return false; //don't execute the default action(scrolling or whatever)
});


//password strength checker
$("#a1").keyup(function () {
    var strength = 1;
    if (this.value.length >= 5) strength++;

    if (this.value.match(/[a-z]/)) strength++;

    var arr = [/{5\,}/, /[a-z]+/];
    $.each(arr, function (i, v) {
        if (this.value.match(v)) strength++;
    });
});