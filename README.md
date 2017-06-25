# Weekend Hacks 1: Umbraco Person Recognition

This is the result of a weekend's work playing around with a face recognition API and Umbraco. Once up and running, the project uses HTML5 APIs and tracking.js to monitor a connected camera for a face. When a face is detected, the browser sends an API request to the back-end server with an image of the face. The server will then call the Kairos facial recognition API to determine if the face is a known person in the system. 

If the person is recognised, their matching Umbraco member object is retrieved and their greeting message is sent back to the browser. The browser then utilises the HTML5 speech API to speak back the user's message. 

This isn't an incredibly useful project in its current state and the main aim was to gain a better understanding of some of the the more obscure HTML5 APIs, the latest Umbraco version and its members API (it uses the saved event on a new member to send the member's image to Kairos to register their face) and to play about with a facial recognition API. 
