/*┌────────────────────────────────────────────────┐
 *│                                                │*
 *│             --> Emoji Flasher <--              │*
 *│                   * By Dan *                   │*
 *│                     v1.0.0                     │*
 *│                                                │*
 *└────────────────────────────────────────────────┘*/

document.addEventListener("DOMContentLoaded", function () {

    // Set the HTML tag
    var emojiTag = document.createElement('my-emoji');  
    
    // Render the emoji and greeting message
    renderEmoji('🤓');

});

function renderEmoji(emoji) {

    var seasonal = document.getElementsByTagName('my-emoji');

    for (var i = 0; i < seasonal.length; i++) {

        // Renders emojis
        var render = seasonal[i].innerHTML = emoji;
    }

    // Sets the timer for the emoji to flash
    setInterval(function () {

        for (var i = 0; i < seasonal.length; i++) {

            var setOpacity = seasonal[i].style.opacity = seasonal[i].style.opacity == "0.15" ? "1.0" : "0.15";

        }

    }, 1000);

}