<template>
    <div id="app">
        <nav class="navbar navbar-expand navbar-dark bg-dark">
            <a href="#" class="navbar-brand">Diamonds Test</a>
            <div class="navbar-nav mr-auto">
                <li class="nav-item">
                    <a href="/Diamonds" class="nav-link">Diamonds</a>
                </li>
                <li class="nav-item">
                    <a href="/AddItem" class="nav-link">Add Item</a>
                </li>
            </div>
        </nav>

        <div class="container mt-3">
            <router-view />
        </div>
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from "vue-property-decorator";

    @Component
    export default class App extends Vue { }
</script>