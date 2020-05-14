<template>
    <div id="app">
        <v-container fluid pa-0 class="top-part" style="height:7rem">
            
            <div class="header-title" >{{title}}</div>
        </v-container>
    </div>

</template>

<script>
    export default {
        name: "SubHeader.vue",
        props : {
            title : String
        }
    }
</script>

<style scoped>

</style>