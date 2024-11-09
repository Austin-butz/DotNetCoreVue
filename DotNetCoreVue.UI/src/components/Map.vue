<template>
    <div>
        <div class="main">
            <l-map :zoom="zoom" :center="center" v-on:ready="onMapReady">
                <l-tile-layer :url="url" :attribution="attribution"></l-tile-layer>
                <l-marker :lat-lng="markerLatLng"></l-marker>
                <div v-for="marker in markers">
                    <l-circle :lat-lng="marker.coordinates" :radius="24000">
                        <l-popup>
                            <div class="container">
                                <div>
                                    <h5 style="overflow-wrap: break-word;">{{ marker.name }}</h5>
                                    <p style="overflow-wrap: break-word;">{{ marker.location }}</p>
                                    <p style="color: blue">{{marker.status}}</p>
                                </div>
                                <div>
                                    <p class="test-box"></p>
                                </div>
                                <div class="break">
                                    <h6>Contact</h6>
                                    <hr />
                                    <p class="break">Director(s): {{ marker.director }} </p>
                                    <p class="break">Email: {{marker.email}}</p>
                                    <p class="break">Phone: {{marker.phone}}</p>
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
                    </l-circle>
                </div>
                <l-circle :lat-lng="[54.9194, -122.7497]" :radius="24000" fill-color="pink" color="pink">
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
                </l-circle>
                <l-control position="bottomleft" class="control-panel">
                    <div>
                        <button v-on:click="goToMe">
                            Find me!!!!
                        </button>
                    </div>
                </l-control>
            </l-map>
        </div>
    </div>
</template>

<script>
    import { onMounted } from 'vue';
    import { LMap, LTileLayer, LMarker, LCircle, LPopup, LControl } from 'vue2-leaflet';

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
            LControl
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
                position: null,
                map: null
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
        }
    }
</script>

<style lang="css" scoped>
    .main {
        height: 500px;

        .control-panel {
            width: 100%;
            height: 1000%;
            background-color: #555;
        }
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

    /*    //html {
    //    background-color: #eee;
    //}*/

    .container {
        margin: 20px auto;
        display: grid;
        grid-template-columns: auto auto;
        grid-row: auto auto;
        grid-column-gap: 20px;
        grid-row-gap: 20px;
        overflow: auto;
        overflow-wrap: break-word;
        word-wrap: break-word;
        word-break: break-all;

        .box {
            /*            //background-color: #333;*/
            padding: 20px;
            border-radius: 10px;
            /*            //color: #fff;*/
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 10px;
            font-family: sans-serif;
        }
    }

    .newthing {
        display: grid;
        grid-template-columns: auto auto;
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

    .break {
/*        overflow: auto;*/
        overflow-wrap: break-word;
        word-wrap: break-word;
        word-break: break-all;
    }
</style>