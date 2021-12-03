var cart = {
    init: function () {
        cart.registerEvents();
    },
    registerEvents: function () {

        function callout() {
            if (window.jQuery) {
                $('.change-price').on('change', function () {
                    var listProduct = $('.change-price');
                    var cartList = [];
                    var click = $(this);
                    Quanity= click.val(),
                    Id = click.data('id'),
                    Size = click.data('s'),
                    Colour = click.data('cl'),
                    $.each(listProduct, function (i, item) {
                        cartList.push({
                            Quanity: $(item).val(),
                            Id: $(item).data('id'),
                            Size: $(item).data('s'),
                            Colour: $(item).data('cl'),
                        });
                    });
                    $.ajax({
                        url: "/Carts/ChangePrice",
                        data: { cartModel: JSON.stringify(cartList) },
                        dataType: "json",
                        type: "POST",
                        success: function (response) {
                            if (response.Price>0) {
                                $(`.total-price-${Id}-${Colour}-${Size}`).html(Quanity * response.Price)
                            }
                        }
                    })
                });


                $('.button_remove').off('click').on('click', function () {
                    var click = $(this);
                    Id = click.data('id'),
                    Size = click.data('s'),
                    Colour = click.data('cl'),
                        $.ajax({
                            url: "/Carts/Remove",
                            data: { Id: Id, Size: Size, Colour: Colour },
                            dataType: "json",
                            type: "DELETE",
                        })
                });
                $('.checkout').off('click').on('click', function () {
                    var click = $(this);
                    /*var cartUser = click.data('id');*/

                    $.ajax({
                        url: "/Carts/Checkout",
                        /*data: { cartUser: cartUser },*/
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