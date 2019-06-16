$(function () {

    var urlParams = new URLSearchParams(window.location.search);
    var queryComment = urlParams.get('comment');
    var queryPost = urlParams.get('post');
    
    // Use session storage to show toast and open already read comment section
    var getStorageEdit = sessionStorage.getItem('type');
    var getStoragePostEdit = sessionStorage.getItem('postEdited');

    if (getStorageEdit === 'edit') {

        toastr.success('Comment edited successfully', 'Success');
        scrollToPost(getStoragePostEdit);
        sessionStorage.clear();

    }
    if (queryComment === 'new') {
        
        toastr.success('Comment added successfully', 'Success');
        
        scrollToPost(queryPost);
        
        removeQueryString();

    }

  
    function removeQueryString() {
        var uri = window.location.toString();
        if (uri.indexOf("?") > 0) {
            var clean_uri = uri.substring(0, uri.indexOf("?"));
            window.history.replaceState({}, document.title, clean_uri);
        }
    }

    // Reopen Button and Text
    function scrollToPost(id) {

        var showComment = $(`#view-comments-btn-${id}`);
        showComment.text().includes('View Comments') ? showComment.text('Hide Comments') : showComment.text('View Comments')
        $(`.view-comments-${id}`).toggle();

        $('html, body').animate(
            {
                scrollTop: $(`#view-comments-btn-${id}`).offset().top,
            },
            500,
            'linear'
        )

    }

});