<template>
    <div id="app">
        <router-view></router-view>
    </div>
</template>

<script>
    export default {
        name: "App.vue"
    }
</script>

<style scoped lang="scss">

    /* APP COLORS */
    $text-color: #000;
    $primary-color: #349868;
    $primary-background-color: #D7E2DE;
    $secondary-background-color: #FFF;

    @font-face {
        font-family: 'Avenir';
        src: url('./assets/fonts/Avenir-Roman/Avenir-Roman.woff2')format('woff2'), url('./assets/fonts/Avenir-Roman/Avenir-Roman.woff')format('woff');
        font-weight: 500;
    }

    @font-face {
        font-family: 'Avenir-Black';
        src: url('./assets/fonts/Avenir-Black/Avenir-Black.woff2')format('woff2'), url('./assets/fonts/Avenir-Black/Avenir-Black.woff')format('woff');
        font-weight: 700;
    }

    @font-face {
        font-family: 'Avenir-Light';
        src: url('./assets/fonts/Avenir-Light/Avenir-Light.woff2') format('woff2'), url('./assets/fonts/Avenir-Light/Avenir-Light.woff') format('woff');
        font-weight: 300;
    }

    #app {
        font-family: "Avenir-Light";
        background-color: $primary-background-color;
    }


</style>