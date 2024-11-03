<template>
    <div class="main fill-container">
        <div class="map fill-container">
            <l-map class="fill-container" :zoom="zoom" :center="center">
                <l-tile-layer :url="url" :attribution="attribution"></l-tile-layer>
                <l-marker :lat-lng="markerLatLng"></l-marker>
            </l-map>
        </div>
    </div>
</template>

<script>
import {LMap, LTileLayer, LMarker} from 'vue2-leaflet';

export default {
  components: {
    LMap,
    LTileLayer,
    LMarker
  },
  data () {
    return {
      url: 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
      attribution:
        '&copy; <a target="_blank" href="http://osm.org/copyright">OpenStreetMap</a> contributors',
      zoom: 15,
      center: [51.505, -0.159],
      markerLatLng: [51.504, -0.159]
    };
  }
}
</script>

<style lang="scss" scoped>
    .main ::v-deep {
        .map {
            height: 66vh;
        }
    }
    .fill-container {
        width: 2000px; /* or any specific width */
        height: 1000px; /* or any specific height */
    }

    html, body {
        height: 100%;
    }
</style>