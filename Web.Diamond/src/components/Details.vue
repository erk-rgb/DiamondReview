<template>
    <main role="main">
        <div class="album py-5 bg-light">
            <div class="container">
                <div class="row" style="margin-bottom:40px;">
                    <div>
                        <span>Item Type</span>
                        <br>
                        <select v-model="selectedType">
                            <option disabled value="">Please select one</option>
                            <option>Engagement</option>
                            <option>Wedding</option>
                        </select>
                    </div>
                    <div>
                        <span>Metal</span>
                        <br>
                        <select v-model="selectedMetal">
                            <option disabled value="">Please select one</option>
                            <option>Yellow Gold</option>
                            <option>Rose Gold</option>
                            <option>White Gold</option>
                            <option>Platinum</option>
                        </select>
                    </div>
                    <div>
                        <span>Shape</span>
                        <br>
                        <select v-model="selectedShape">
                            <option disabled value="">Please select one</option>
                            <option>Round</option>
                            <option>Cushion</option>
                        </select>
                    </div>
                    <div>
                        <span>Photo</span>
                        <br>
                        <<input name="fuPhoto" type="file" id="input">
                    </div>
                    <div>
                        <span>Thumb</span>
                        <br>
                        <<input name="fuThumb" type="file" id="input">
                    </div>
                    <div>
                        <button type="button" class="btn btn-sm btn-outline-secondary">Save</button>
                    </div>
                </div>


                <h2>Rounds</h2>
                <div class="row">
                    <div v-for="post in filter(posts,'Round')" class="col-md-12">
                        <div class="col-md-2">{{post.itemType}}</div>
                        <div class="col-md-2">{{post.metalValue}}</div>
                        <div class="col-md-2">{{post.shapeValue}}</div>
                        <div class="col-md-2"><img :src="getPhotoSrc(post)" class="img-fluid"></div>
                        <div class="col-md-2"><img :src="getThumbSrc(post)" class="img-fluid"></div>
                        <div class="col-md-2"> <button type="button" class="btn btn-sm btn-outline-secondary">Save</button></div>
                    </div>
                </div>
                <h2>Cushions</h2>
                <div class="row">
                    <div v-for="post2 in filter(posts,'Cushion')" class="col-md-12">
                        <div class="col-md-2">{{post2.itemType}}</div>
                        <div class="col-md-2">{{post2.metalValue}}</div>
                        <div class="col-md-2">{{post2.shapeValue}}</div>
                        <div class="col-md-4"><img :src="getPhotoSrc(post2)" class="img-fluid"></div>
                        <div class="col-md-2"><img :src="getThumbSrc(post2)" class="img-fluid"></div>
                        <div class="col-md-2"> <button type="button" class="btn btn-sm btn-outline-secondary">Save</button></div>
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
            getThumbSrc(pos: diamond) {
                if (pos.thumb == null) {
                    return '';
                }
                return require('../assets/gallery/' + pos.thumb)
            },
            getPhotoSrc(pos: diamond) {
                if (pos.fileName == null) {
                    return '';
                }
                return require('../assets/gallery/' + pos.fileName)
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
</style>