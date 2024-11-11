<template>
    <div>
        <div class="main">
            <l-map :zoom="zoom" :center="center" v-on:ready="onMapReady">
                <l-tile-layer :url="url" :attribution="attribution"></l-tile-layer>
                <l-marker :lat-lng="markerLatLng"></l-marker>
                <div v-for="marker in viewableMarkers">
                    <l-circle :lat-lng="marker.coordinates" :radius="24000">
                        <l-popup :options="popupOptions">
                            <div class="container">
                                <div>
                                    <h5 style="overflow-wrap: break-word;">{{ marker.name }}</h5>
                                    <span style="overflow-wrap: break-word;">{{ marker.location }}</span>
                                    <span style="color: blue">{{marker.status}}</span>
                                </div>
                                <div>
                                    <p class="test-box"></p>
                                </div>
                                <div class="break">
                                    <h6>Contact</h6>
                                    <hr />
                                    Director(s):
                                    <br />
                                    <b>{{ marker.director }} </b>
                                    <br />
                                    Email:
                                    <br />
                                    <b>{{marker.email}}</b>
                                    <br />
                                    Phone:
                                    <br />
                                    <b>{{marker.phone}}</b>
                                </div>
                                <div>
                                    <div>
                                        <div class="pill">
                                            sample tag
                                        </div>
                                        <div class="pill">
                                            sample tag
                                        </div>
                                        <div class="pill">
                                            sample tag
                                        </div>
                                        <div class="pill">
                                            sample tag
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </l-popup>
                    </l-circle>
                </div>
                <!--<l-circle :lat-lng="[54.9194, -122.7497]" :radius="24000" fill-color="pink" color="pink">
                    <l-popup>
                        <div class="container">
                            <div>
                                <h5 style="overflow-wrap: break-word;">{.name }</h5>
                                <p style="overflow-wrap: break-word;">{ marker.locat</p>
                                <p style="color: blue">{marker.statu}</p>
                            </div>
                            <div>
                                <p class="test-box"></p>
                            </div>
                            <div>
                                <h6>Contact</h6>
                                <hr />
                                <p style="overflow-wrap: break-word;">Director(s): {arker.director } </p>
                                <p style="overflow-wrap: break-word;">Email: {marker.email}</p>
                                <p style="overflow-wrap: break-word;">Phone: {marker.phone}</p>
                            </div>
                            <div>
                                <div class="container">
                                    <div>
                                        sample tag
                                    </div>
                                    <div>
                                        sample tag
                                    </div>
                                    <div>
                                        sample tag
                                    </div>
                                    <div>
                                        sample tag
                                    </div>
                                </div>
                            </div>
                        </div>
                    </l-popup>
                </l-circle>-->
                <l-control position="bottomleft" class="control-panel">
                    <div>
                        <button v-on:click="goToMe" class="pill" style="padding: 10px">
                            Find me!!!!
                        </button>
                    </div>
                </l-control>
                <l-control position="topright">
                    <div style="border-radius: 25px; border: 2px solid #73AD21; padding: 20px">
                        <multiselect 
                            v-model="chosenSpecies" 
                            :options="speciesOptions"
                            placeholder="Choose a species"
                            :searchable="true"
                            :close-on-select="false"
                            :show-labels="true"></multiselect>
                    </div>
                </l-control>
            </l-map>
        </div>
    </div>
</template>

<script>
    import { onMounted } from 'vue';
    import { LMap, LTileLayer, LMarker, LCircle, LPopup, LControl } from 'vue2-leaflet';
    import Multiselect from 'vue-multiselect'
    //import 'vue-multiselect/dist/vue-multiselect.min.css' //is this working?
    //import 'vue2-leaflet'

    export default {
        props: {
            viewData: Object
        },
        components: {
            LMap,
            LTileLayer,
            LMarker,
            LCircle,
            LPopup,
            LControl,
            Multiselect
        },
        data() {
            return {
                url: 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
                attribution:
                    '&copy; <a target="_blank" href="http://osm.org/copyright">OpenStreetMap</a> contributors',
                zoom: 5,
                center: [
                    39.1626,
                    -76.6247
                ],
                markerLatLng: [51.504, -0.159],
                markers: [],
                viewableMarkers: [],
                position: null,
                map: null,
                popupOptions: {
                    width: "400px"
                },
                speciesOptions: ['all', 'ferret', 'dog', 'cat', 'avian'],
                chosenSpecies: null
            };
        },
        methods: {
            boxA() {
                console.log(this.viewData)
            },
            goToMe() {
                console.log(this.position, this.map)
                if (this.position.coords.latitude === null) return
                this.map.panTo([this.position.coords.latitude, this.position.coords.longitude])
            },
            onMapReady(map) {
                this.map = map;
            }
        },
        mounted() {
            var self = this;
            function success(position) {
                console.log("location loaded")
                self.position = position;
            }
            function error(error) {
                console.log(error)
            }
            var options = {
                enableHighAccuracy: false,
                timeout: 5000,
                maximumAge: Infinity
            }
            navigator.geolocation.getCurrentPosition(success, error, options);

            console.log(this.viewData)
            this.markers = this.viewData.rescues.shelters;
            this.viewableMarkers = this.markers;
        },
        watch: {
            chosenSpecies(value) {
                if (value == 'all') {
                    this.viewableMarkers = this.markers
                }
                else {
                    this.viewableMarkers = this.markers.filter(marker => marker.species == value);
                }
            }
        }
    }
</script>

<style lang="css" scoped>
    .main {
        height: 750px;
    }

    .leaflet-popup-content {
        width: auto !important;
    }

    .control-panel {
        width: 100%;
        height: 1000%;
/*        background-color: #555;*/
    }

    p {
        line-height: 1px;
    }

    html, body {
        height: 100%;
    }

    * {
        margin: 0;
        padding: 0;
        box-sizing: border-box;
    }

    .container {
        margin: 20px auto;
        display: grid;
        grid-template-columns: 50% auto;
        grid-row: auto auto;
        grid-column-gap: 20px;
        grid-row-gap: 20px;
    }

    .test-box {
        background-color: #333;
        padding: 40px;
        border-radius: 10px;
        color: #fff;
        display: flex;
        align-items: center;
        justify-content: center;
        font-size: 40px;
        font-family: sans-serif;
    }

    .pill {
        padding: 1px;
        margin: 5px;
        border-radius: 30px;
        background-color: blue;
        border: none;
        color: white;
        text-align: center
    }

    .break {
        overflow: hidden;
        word-break: break-word;
        word-wrap: break-word;
    }
</style>