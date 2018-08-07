window.addEventListener('load', function () {

    // Fetching all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.getElementsByClassName('needs-validation');
    // Looping over them and prevent submission
    var validation = Array.prototype.filter.call(forms, function (form) {
        form.addEventListener('submit', function (event) {
            if (form.checkValidity() === false) {
                event.preventDefault();
                event.stopPropagation();
            }
            form.classList.add('was-validated');
        }, false);
    });


    // Filling in my client key
    var clientKey = "js-gBE4qlpxgI0Q0elxYSjkd6jNrJyisPA0js10AsEWkuYMkuI30W9NxDXHDrOCKPno";

    var cache = {};
    var container = $("#address-block");
    var errorDiv = container.find("div.text-error");

    /* Handling successful response of current address zip code section*/
    function handleResp(data) {
        // Checking for error
        if (data.error_msg)
            errorDiv.text(data.error_msg);
        else if ("city" in data) {
            // Setting city and state
            container.find("input[name='current-city']").val(data.city);
            container.find("input[name='current-state']").val(data.state);
        }
    }

    // Setting up event handlers for current address zipcode
    $(document).on("keyup change", "input[name='current-zipcode']", function () {
        // Getting zip code
        var zipcode = $(this).val().substring(0, 5);
        if (zipcode.length == 5 && /^[0-9]+$/.test(zipcode)) {
            // Clearing error
            errorDiv.empty();

            // Checking cache
            if (zipcode in cache) {
                handleResp(cache[zipcode]);
            }
            else {
                // Building url
                var url = "http://www.zipcodeapi.com/rest/" + clientKey + "/info.json/" + zipcode + "/radians";

                // Making AJAX request
                $.ajax({
                    "url": url,
                    "dataType": "json"
                }).done(function (data) {
                    handleResp(data);

                    // Storing in cache
                    cache[zipcode] = data;
                }).fail(function (data) {
                    if (data.responseText && (json = $.parseJSON(data.responseText))) {
                        // Storing in cache
                        cache[zipcode] = json;

                        // Checking for error
                        if (json.error_msg)
                            errorDiv.text(json.error_msg);
                    }
                    else
                        errorDiv.text('Request failed.');
                });
            }
        }
    }).trigger("change");



    /* Zip code related functionality for permanent address starts here section */
    var cache_1 = {};
    var container_1 = $("#permanent-address-block");
    var errorDiv_1 = container_1.find("div.text-error");

    /* Handling successful response of current address zip code section*/
    function handleResp_1(data) {
        // Check for error
        if (data.error_msg)
            container_1.find("div.text-error").text(data.error_msg);
        else if ("city" in data) {
            // Set city and state
            container_1.find("input[name='permanent-city']").val(data.city);
            container_1.find("input[name='permanent-state']").val(data.state);
        }
    }

    // Setting up event handlers for current address zipcode
    $(document).on("keyup change", "input[name='permanent-zipcode']", function () {
        // Getting zip code
        var zipcode = $(this).val().substring(0, 5);
        if (zipcode.length == 5 && /^[0-9]+$/.test(zipcode)) {
            // Clearing error
            container_1.find("div.text-error").empty();

            // Checking cache
            if (zipcode in cache_1) {
                handleResp_1(cache_1[zipcode]);
            }
            else {
                // Building url
                var url = "http://www.zipcodeapi.com/rest/" + clientKey + "/info.json/" + zipcode + "/radians";

                // Making AJAX request
                $.ajax({
                    "url": url,
                    "dataType": "json"
                }).done(function (data) {
                    handleResp_1(data);

                    // Storing in cache
                    cache_1[zipcode] = data;
                }).fail(function (data) {
                    if (data.responseText && (json = $.parseJSON(data.responseText))) {
                        // Storing in cache
                        cache_1[zipcode] = json;

                        // Checking for error
                        if (json.error_msg)
                            container_1.find("div.text-error").text(json.error_msg);
                    }
                    else
                        container_1.find("div.text-error").text('Request failed.');
                });
            }
        }
    }).trigger("change");

}, false);


/* current and permanent address related functionality */
function checkAddress() {
    //get the value t=of dropdown
    var check = document.getElementById("address-same").value;
    var required;

    //check if value is yes or no and then display or hide the permanent address block
    if (check == "Y" || check == "") {
        document.getElementById("permanent-address-block").style.display = "none";
        required = false;
        deletePermanentAddress();
    } else {
        document.getElementById("permanent-address-block").style.display = "block";
        required = true;
        createPermanentAddress();
    }

    //search for all elements in the permanent address and make them required or not based on the dropdown value
    //var matches = [];
    //var searchEles = document.getElementById("permanent-address-block").querySelectorAll('.form-control');
    //for (var i = 0; i < searchEles.length; i++) {
    //    if (searchEles[i].tagName == 'SELECT' || searchEles[i].tagName == 'INPUT') {
    //        searchEles[i].required = required;
    //    }
    //}

   
}

/* Delete permanent address elements */
function deletePermanentAddress() {
    document.getElementById("permanent-address").innerHTML = "";
    document.getElementById("permanent-address-2").innerHTML = "";
    document.getElementById("permanent-city").innerHTML = "";
    document.getElementById("permanent-state").innerHTML = "";
    document.getElementById("permanent-country").innerHTML = "";
    document.getElementById("permanent-zipcode").innerHTML = "";
}

/* creates permanent address elements */
function createPermanentAddress() {

    //create address line 1
    var permanent_address = document.getElementById("permanent-address");
    var label = document.createElement("label");
    label.setAttribute("for", "permanent-address");
    label.className = "col-sm-2";
    label.innerText = "Address";
    var div = document.createElement("div");
    div.className = "col-sm-10";
    var input = document.createElement("input");
    input.setAttribute("name", "permanent-address");
    input.setAttribute("placeholder", "Enter your address here");
    input.setAttribute("required", "");
    input.className = "form-control";
    var error = document.createElement("div");
    error.className = "invalid-feedback";
    error.innerHTML = "Please provide a Address.";
    permanent_address.appendChild(label);
    div.appendChild(input);
    div.appendChild(error);
    permanent_address.appendChild(div);


    //create address line 2
    var permanent_address_2 = document.getElementById("permanent-address-2");
    var label = document.createElement("label");
    label.setAttribute("for", "permanent-address-2");
    label.className = "col-sm-2";
    label.innerText = "Address 2";
    var div = document.createElement("div");
    div.className = "col-sm-10";
    var input = document.createElement("input");
    input.setAttribute("name", "permanent-address-2");
    input.setAttribute("placeholder", "Apt, flr, etc");
    input.setAttribute("required", "");
    input.className = "form-control";
    var error = document.createElement("div");
    error.className = "invalid-feedback";
    error.innerHTML = "Please provide a Address.";
    permanent_address_2.appendChild(label);
    div.appendChild(input);
    div.appendChild(error);
    permanent_address_2.appendChild(div);


    //create City
    var permanent_city = document.getElementById("permanent-city");
    var label = document.createElement("label");
    label.setAttribute("for", "permanent-city");
    label.className = "col-sm-2";
    label.innerText = "City";
    var div = document.createElement("div");
    div.className = "col-sm-10";
    var input = document.createElement("input");
    input.setAttribute("name", "permanent-city");
    input.setAttribute("placeholder", "City");
    input.setAttribute("required", "");
    input.className = "form-control";
    var error = document.createElement("div");
    error.className = "invalid-feedback";
    error.innerHTML = " Please provide a City.";
    permanent_city.appendChild(label);
    div.appendChild(input);
    div.appendChild(error);
    permanent_city.appendChild(div);


    //create state
    var permanent_state = document.getElementById("permanent-state");
    var label = document.createElement("label");
    label.setAttribute("for", "permanent-state");
    label.className = "col-sm-2";
    label.innerText = "State";
    var div = document.createElement("div");
    div.className = "col-sm-10";
    var input = document.createElement("input");
    input.setAttribute("name", "permanent-state");
    input.setAttribute("placeholder", "State");
    input.setAttribute("required", "");
    input.className = "form-control";
    var error = document.createElement("div");
    error.className = "invalid-feedback";
    error.innerHTML = " Please provide a State.";
    permanent_state.appendChild(label);
    div.appendChild(input);
    div.appendChild(error);
    permanent_state.appendChild(div);


    //create country
    var permanent_country = document.getElementById("permanent-country");
    var label = document.createElement("label");
    label.setAttribute("for", "permanent-country");
    label.className = "col-sm-2";
    label.innerText = "Country";
    var div = document.createElement("div");
    div.className = "col-sm-10";
    var select = document.createElement("select");
    select.setAttribute("name", "permanent-country");
    select.setAttribute("required", "");
    select.className = "form-control";
    var option = document.createElement("option");
    option.setAttribute("value", "");
    option.innerHTML = "Select Country Code";
    select.appendChild(option);
    option = document.createElement("option");
    option.innerHTML = "Nigeria";
    select.appendChild(option);
    option = document.createElement("option");
    option.innerHTML = "Senegal";
    select.appendChild(option);
    option = document.createElement("option");
    option.innerHTML = "India";
    select.appendChild(option);
    option = document.createElement("option");
    option.innerHTML = "Mali";
    select.appendChild(option);
    option = document.createElement("option");
    option.innerHTML = "USA";
    select.appendChild(option);
    var error = document.createElement("div");
    error.className = "invalid-feedback";
    error.innerHTML = "Please select Country.";
    permanent_country.appendChild(label);
    div.appendChild(select);
    div.appendChild(error);
    permanent_country.appendChild(div);


    //create zip
    var permanent_zipcode = document.getElementById("permanent-zipcode");
    var label = document.createElement("label");
    label.setAttribute("for", "permanent-zipcode");
    label.className = "col-sm-2";
    label.innerText = "Zip";
    var div = document.createElement("div");
    div.className = "col-sm-10";
    var input = document.createElement("input");
    input.setAttribute("name", "permanent-zipcode");
    input.setAttribute("placeholder", "Zip");
    input.setAttribute("required", "");
    input.className = "form-control";
    var error = document.createElement("div");
    error.className = "invalid-feedback";
    error.innerHTML = " Please provide a Valid Zip Code.";
    var zipError = document.createElement("div");
    zipError.className = "text-error";
    permanent_zipcode.appendChild(label);
    div.appendChild(input);
    div.appendChild(error);
    div.appendChild(zipError);
    permanent_zipcode.appendChild(div);
}


function postPerson() {
    var person = {
        "firstName": document.getElementById("first-name").value,
        "lastName": document.getElementById("last-name").value,
        "houseNo": document.getElementById("current-address-2").value,
        "streetName": document.getElementById("current-address").value,
        "city": document.getElementById("current-city").value,
        "state": document.getElementById("current-state").value,
        "zipCode": document.getElementById("current-zipcode").value,
        "country": document.getElementById("current-country").value,
        "countryCode": document.getElementById("country-code").value,
        "phone": document.getElementById("phone").value,
    }

    $.ajax({
        type: "Post",
        url: "http://localhost:64799/api/Person",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(contact),
            success: function (response) {
                alert(response);
            },
            error: function (response) {
                console.log(response);
            }
        });
}

























































//function checkAddr() {
//    var check = document.querySelector("#CheckAddress").value;
//    if (check === 2) { //check user have selected No
//        // get reference of the element to be selected
//        var address2 = document.querySelector("#address2"); // get reference of the element to be selected
//        var h3 = document.createElement("h3"); // create a new element in the DOM tree
//        h3.innerText = "Permanent Address"; // Add inner Text to it
//        var label = document.createElement("label"); // create another element
//        label.innerText = "Address Line 1"; // add inner text to it
//        var add1 = document.createElement("input"); // create a text attribute
//        add1.setAttribute("type", "text"); // set attribute
//        address2.appendChild(h3); // tie the elements to the parent (<div id=address2)>)
//        address2.appendChild(label); // tie the elements to the parent (<div id=address2)>)
//        address2.appendChild(add1); // tie the elements to the parent (<div id=address2)>)
//    }
//};



//function welcome() {
//    var firstName = document.querySelector("#exampleFirstName").value;
//    var dara = document.querySelectorAll("input");
//    alert("welcome " + firstName);

//}