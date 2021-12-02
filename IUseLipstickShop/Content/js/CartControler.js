var cart = {
    init: function () {
        cart.registerEvents();
    },
    registerEvents: function () {

        function callout() {
            if (window.jQuery) {
                $('.change-price').on('change', function () {
                    var input = $(this);
                    var prime = input.data('id');
                    var quanity = input.val();
                    $.ajax({
                        url: "/Carts/ChangePrice",
                        data: { prime: prime, quanity: quanity },
                        dataType: "json",
                        type: "POST",
                        success: function (response) {
                            if (response.QuanityPice > 0) {
                                $(`.total-price-${prime}`).html(response.QuanityPice)
                            }
                        }
                    })
                });


                $('.button_remove').off('click').on('click', function () {
                    var click = $(this);
                    var prime = click.data('id');
                    
                    $.ajax({
                        url: "/Carts/Remove",
                        data: { prime: prime},
                        dataType: "json",
                        type: "DELETE",
                        success: function (response) {
                            if (response.status == true) {
                                window.location.href = "/Carts";
                            }
                        }
                    })
                });
                $('.checkout').off('click').on('click', function () {
                    var click = $(this);
                    var cartUser = click.data('id');

                    $.ajax({
                        url: "/Carts/Checkout",
                        data: { cartUser: cartUser },
                        dataType: "json",
                        type: "POST",
                        success: function (response) {
                            if (response.totalCheck > 0) {
                                $('.total-checkout').html(response.totalCheck)
                            }
                        }
                    })
                });
            }
            else {
                setTimeout(callout,500);
            }
        }
        callout()
    }
}
cart.init();