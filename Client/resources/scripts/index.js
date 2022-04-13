const BASEURL = "https://localhost:5001/api/songs";
var songList =[];

const handleOnLoad = () => {
    dataInit();
    
}

function dataInit() {
    fetch(BASEURL).then(function(response) {
		console.log(response);
		return response.json();
	}).then(function(data) {
        console.log(data)
        songList = data;
        updateDomSongList();
    }).catch(function(error) {
		console.log(error);
	});
		
}
 function updateDomSongList() {
     console.log("Heree");
    let html = ``;
    songList.forEach((song) => { // data is an array consisting of song jsons
        html += `<div class="card col-md-4 bg-dark text-white">`;
        html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
        
        html += `<div class="card-img-overlay">`;
        if (song.favorited === "y") {
            html += `<img src="./resources/images/favorite_icon.png" align = "right" height = "80px" alt="Fav Icon">`;
        }
        
        html += `<h5 class="card-title">`+song.songTitle+`</h5>`;
        html += `<button onclick = makeFavorite(`+song.songID+`)>Favorite</button>`;
        html += `<button onclick = deleteSong(`+song.songID+`)>Delete</button>`;
        console.log(song.songID);
        
        html += `</div>`;
        html += `</div>`;
    });
    
    if(html === ``){
        html = "No Songs found :("
    
    }
    console.log(html);
    document.getElementById("cardList").innerHTML = html;
 }

function findSongs(){
    var url = "https://www.songsterr.com/a/ra/songs.json?pattern="
    let searchString = document.getElementById("searchSong").value;

    url += searchString;

    console.log(searchString)

    fetch(url).then(function(response) {
		console.log(response);
		return response.json();
	}).then(function(data) {
        console.log(data)
        let html = ``;
		data.forEach((song) => { // data is an array consisting of song jsons
            console.log(song.title)
            html += `<div class="card col-md-4 bg-dark text-white">`;
			html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
			html += `<div class="card-img-overlay">`;
			html += `<h5 class="card-title">`+song.title+`</h5>`;
            html += `</div>`;
            html += `</div>`;
		});
		
        if(html === ``){
            html = "No Songs found :("
        }
		document.getElementById("searchSongs").innerHTML = html;

	}).catch(function(error) {
		console.log(error);
	})
}



function postSong() {
    const songTitle = document.getElementById("title").value;
    document.getElementById("title").value = "";
    console.log(songTitle);
    fetch(BASEURL, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            songTitle: songTitle
        })
    })
    .then((response)=>{
        console.log(response);
        dataInit();
    })
}

function makeFavorite(id) {
    console.log("I am here");
    console.log(id);
    let url = BASEURL + "/" + id;
    console.log(url);

    fetch(url, {
        
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        }
    })
    .then((response)=>{
        console.log(response);
        dataInit();
    })
}

function deleteSong(id) {
    console.log("I am here");
    console.log(id);
    let url = BASEURL + "/" + id;
    console.log(url);

    fetch(url, {
        
        method: "DELETE",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        }
    })
    .then((response)=>{
        console.log(response);
        dataInit();
    })
}

