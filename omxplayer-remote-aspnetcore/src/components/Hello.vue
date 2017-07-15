<template>
  <div class="content">
    <div class="films">
      <h1>Films</h1>
      <ul>
        <li v-for="film in films">
          <a href="javascript:void(0);" :data-path="film.path" v-on:click="open">{{film.title}}</a>
        </li>
      </ul>
      <button v-on:click="stop">Stop</button>
      <button v-on:click="pause">Pause</button>
    </div>
    <div class="streams">
      <h1>Streams</h1>
      <input id="stream" type="text" />
      <button v-on:click="playStream">Play</button>
      <ul>
        <li v-for="stream in recentStreams">
          <a href="javascript:void(0);" :data-path="stream.path" v-on:click="livestreamerPlay($event, stream.path)">{{stream.title}}</a>
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
export default {
  name: 'hello',
  data () {
    return {
      msg: 'Welcome to Your Vue.js App',
      films: {},
      recentStreams: {}
    }
  },
  methods: {
    updateFilms: function () {
      this.$http
        .get('/api/source/films')
        .then((res) => {
          this.films = res.body
        })
        .catch((ex) => console.log(ex))
    },
    updateRecentStreams: function () {
      this.$http
        .get('/api/source/recentstreams')
        .then((res) => {
          this.recentStreams = res.body
        })
        .catch((ex) => console.log(ex))
    },
    open: function (event) {
      this.$http
        .post('/api/omxplayer/play', { path: event.target.dataset.path })
    },
    livestreamerPlay: function (event, url) {
      this.$http
        .post('/api/livestreamer/play', { path: url })
        .then(() => {
          this.updateRecentStreams()
        })
    },
    playStream: function (event) {
      this.livestreamerPlay(event, document.getElementById('stream').value)
    },
    stop: function (event) {
      this.$http
        .post('/api/omxplayer/stop')
      this.$http
        .post('/api/livestreamer/stop')
    },
    pause: function (event) {
      this.$http
        .post('/api/omxplayer/pause')
      this.$http
        .post('/api/livestreamer/pause')
    }
  },
  created () {
    this.updateFilms()
    this.updateRecentStreams()
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1, h2 {
  font-weight: normal;
}

ul {
  padding: 0;
}

li {
  margin: 0 10px;
}

a {
  color: #42b983;
}
</style>
