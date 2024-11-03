import Vue from 'vue';

import HelloWorld from './HelloWorld.vue';
import MapApp from './Map.vue'

export default {
    loadComponents() {
        new Vue({
            el: "#app",
            components: { MapApp },
            render(createElement) {
                return createElement(MapApp, { props: { viewData: window.data } })
            }
        })
    }
}