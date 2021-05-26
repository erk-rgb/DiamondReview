<template>
    <main role="main">
        <div class="album py-5 bg-light">
            <div class="container">
                <h2>Rounds</h2>
                <div class="row">
                    <!--round > yellow gold -->
                    <div v-for="post in filter(posts,'Round')" class="col-md-4">
                        <div class="card mb-4 box-shadow" style="margin-bottom:10px;">
                            <div v-bind:id="getCarousel(post.id,1)" class="carousel slide" data-ride="carousel" align="center">
                                <!-- slides -->
                                <div class="carousel-inner">
                                    <div class="carousel-item active" style="height:200px;"> <img :src="getPhotoSrc(post)"> </div>
                                </div> <!-- Thumbnails -->
                                <ol class="carousel-indicators list-inline">
                                    <li class="list-inline-item active"> <a id="carousel-selector-0" class="selected" data-slide-to="0" v-bind:data-target="getCarousel(post.id,2)"> <img :src="getThumbSrc(post)" class="img-fluid"> </a> </li>
                                </ol>
                            </div>
                            <p class="card-text"></p>
                            <div class="card-body">
                                <p class="card-text"></p>
                                <div class="d-flex justify-content-between align-items-center">
                                    <div class="btn-group">
                                    </div>
                                    <small class="text-muted">{{post.metalValue}}</small>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <h2>Cushions</h2>
                <div class="row">
                    <!--round > yellow gold -->
                    <div v-for="post2 in filter(posts,'Cushion')" class="col-md-4">
                        <div class="card mb-4 box-shadow" style="margin-bottom:10px;">
                            <div v-bind:id="getCarousel(post2.id,1)" class="carousel slide" data-ride="carousel" align="center">
                                <!-- slides -->
                                <div class="carousel-inner">
                                    <div class="carousel-item active" style="height:200px;"> <img :src="getPhotoSrc(post2)"> </div>
                                </div> <!-- Thumbnails -->
                                <ol class="carousel-indicators list-inline">
                                    <li class="list-inline-item active"> <a id="carousel-selector-0" class="selected" data-slide-to="0" v-bind:data-target="getCarousel(post2.id,2)"> <img :src="getThumbSrc(post2)" class="img-fluid"> </a> </li>
                                </ol>
                            </div>
                            <p class="card-text"></p>
                            <div class="card-body">
                                <p class="card-text"></p>
                                <div class="d-flex justify-content-between align-items-center">
                                    <div class="btn-group">
                                    </div>
                                    <small class="text-muted">{{post2.metalValue}}</small>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</template>

<script lang="ts">
    import axios from 'axios';
    import diamond from '@/types/diamond';

    export default {
        data() {
            return {
                posts: [] as diamond[]
            }
        },
        methods: {
            filter(arr = [] as diamond[], type = '') {
                if (arr && arr.length) {
                    console.log(arr);
                    if (length == -1) {
                        return null;
                    }
                    return arr.filter(dia => dia.shapeValue === type);
                }
                return null;
            },
            getCarousel(id = '', type = 0) {
                if (type == 1) {
                    return 'caru' + id;
                }

                return '#caru' + id;
            },
            getThumbSrc(pos: diamond) {
                if (pos.thumb == null) {
                    return '';
                }
                return require('../assets/gallery/' + pos.thumb)
                //var images = require.context('../assets/gallery/', false, /\.jpg$/)
                //return images('./' + pos.thumb)
            },
            getPhotoSrc(pos: diamond) {
                if (pos.fileName == null) {
                    return '';
                }
                return require('../assets/gallery/' + pos.fileName)
                //var images = require.context('../assets/gallery/', false, /\.jpg$/)
                //return images('./' + pos.fileName)
            }
        },
        created() {
            axios.get('http://localhost:53205/api/diamond/GetDiamondsAsync')
                .then(response => {
                    // @ts-ignore:
                    this.posts = response.data;
                    // @ts-ignore:
                    console.log(this.posts);
                })
                .catch((e) => {
                    console.log(e);
                });
        }
    }
</script>

<style scoped>
    .carousel-indicators {
        position: static;
        margin-top: 20px
    }

        .carousel-indicators > li {
            width: 100px
        }

        .carousel-indicators li img {
            display: block;
            opacity: 0.5
        }

        .carousel-indicators li.active img {
            opacity: 1
        }

        .carousel-indicators li:hover img {
            opacity: 0.75
        }

    .carousel-item img {
        width: 100%
    }
</style>