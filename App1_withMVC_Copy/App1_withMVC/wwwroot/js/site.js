// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#pagination').DataTable();
});

var index = 2;
$(document).ready(function () {
    // Add education section button click event
    $('#addEducationSection').click(function () {
        var newSection = $('.educationSection:first ').clone(); // Clone the education section template
        newSection.find('input:text').val('');
        newSection.attr('id', index);
        $('#educationContainer').append(newSection); // Append the cloned section to the container
        index
        id++;
    });

    // Remove education section button click event
    $(document).on('click', '.removeEducationSection', function () {
        $(this).closest('.educationSection').remove(); // Remove the clicked education section
    });
    // -----------------------------------------------------------------------
    // code to pass data from view to controller on click
});

$(document).ready(function () {

    $('#regtest').click(function (event) {
        var formData = [];
        $('input.pqr , select.pqr').each(function () {
            formData.push($(this).val());
        });
        console.log(formData);
        event.stopPropagation();
        event.preventDefault();

        // make ajax call
        var ajax1 = $.ajax({
            url: '/student/regform', // replace with the actual url of your controller endpoint
            type: 'post', // or 'get' depending on your requirements
            data: {
                FirstName: $('#FN').val(),
                LastName: $('#LN').val(),
                StudentEmail: $('#SE').val(),
                StudentPassword: $('#SP').val(),
                Sque: $('#Sque').val(),
                Sans: $('#Sans').val(),
                Qualification: $('#Qualification').val(),
                InstName: $('#IN').val(),
                PassYear: $('#PY').val(),
                Score: $('#SC').val(),
            }
        });
        //success: function (response) {
        //    // handle the response from the controller
        //    console.log(response);
        //},
        //error: function (xhr, status, error) {
        //    // handle any errors that occurred during the ajax request
        //    console.log(error);
        //}

        var ajax2 = $.ajax({
            url: '/Student/InsertDynamicInfo',
            method: 'POST',
            data: { formData: formData, FirstName: $('#FN').val() },
            //contentType: 'application/json',
            headers: {
                'Cache-Control': 'no-cache'
            },
            //success: function (response) {
            //    // Handle success response from the server
            //},
            //error: function (xhr, status, error) {
            ////    // Handle error response from the server
            //},
        });

        $.when(ajax1, ajax2).done(function (response1, response2) {
            // Both AJAX calls completed successfully
            // Handle the responses if needed

            // Redirect the user to the desired URL
            window.location.href = '/Student/LoginForm';
        });
    });
});


$(document).ready(function () {

    $('#saveEditedProfile').click(function (event) {
        var editedData = [];
        $('#QU1 , #IN1 , #PY1 , #SC1').each(function () {
            editedData.push($(this).val());
        });

        var basicInfo = [];
        $('#FN1 ,#LN1 , #EM1, #PW1 , #SQ1 , #SA1').each(function () {
            basicInfo.push($(this).val());
        });
        var StudentID =  $('#ID1').val()
        var ajax3 = $.ajax({
            url: '/student/EditedProf', // replace with the actual url of your controller endpoint
            type: 'post', // or 'get' depending on your requirements
            data: { basicInfo: basicInfo, StudentID },
            headers: {
                'Cache-Control': 'no-cache'
            },
        });

        var StudentID = $('#ID1').val()
        var ajax4 = $.ajax({
            url: '/Student/editProfileLater',
            method: 'POST',
            data: { editedData: editedData, StudentID },
            headers: {
                'Cache-Control': 'no-cache'
            },
            //success: function (response) {
            //    // Handle success response from the server
            //},
            //error: function (xhr, status, error) {
            ////    // Handle error response from the server
            //},
        });

        $.when(ajax3, ajax4).done(function (response1, response2) {
            // Both AJAX calls completed successfully
            // Handle the responses if needed

            // Redirect the user to the desired URL
            window.location.href = '/Student/ShowUsers';
        });

    });

});