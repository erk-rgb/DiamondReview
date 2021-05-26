<template>
    <main role="main" style="font-family:Tahoma;">
        <div class="album py-5 bg-light">
            <div class="container" style="zoom:0.9">
                <h3 style="text-decoration:underline;">Add Item</h3>
                <div class="col-md-12" style="display:flex; margin-bottom:40px;width:100%;zoom:0.9">
                    <div class="col-md-2" style="margin:10px">
                        <span style="font-weight:bold;">Item Type</span>
                        <br><br>
                        <select v-model="diamondEntity.itemTypeId" required>
                            <option disabled value="-1">Please select one</option>
                            <option value="1">Engagement</option>
                            <option value="2">Wedding</option>
                        </select>
                    </div>
                    <div class="col-md-2" style="margin:10px">
                        <span style="font-weight:bold;">Metal</span>
                        <br><br>
                        <select v-model="diamondEntity.metalValue" required>
                            <option disabled value="-1">Please select one</option>
                            <option value="Yellow Gold">Yellow Gold</option>
                            <option value="Rose Gold">Rose Gold</option>
                            <option value="White Gold">White Gold</option>
                            <option value="Platinum">Platinum</option>
                        </select>
                    </div>
                    <div class="col-md-2" style="margin:10px">
                        <span style="font-weight:bold;">Shape</span>
                        <br><br>
                        <select v-model="diamondEntity.shapeValue" required>
                            <option disabled value="-1">Please select one</option>
                            <option value="Round">Round</option>
                            <option value="Cushion">Cushion</option>
                        </select>
                    </div>
                    <div class="col-md-2" style="margin:10px">
                        <span style="font-weight:bold;">Photo</span>
                        <br><br>
                        <input name="fuPhoto" type="file" ref="filePhoto" id="fuPhoto" v-on:change="getPhotoFile" required>
                    </div>
                    <div class="col-md-2" style="margin:10px">
                        <span style="font-weight:bold;">Thumb</span>
                        <br><br>
                        <input name="fuThumb" type="file" ref="fileThumb" id="fuThumb" v-on:change="getThumbFile" required>
                    </div>
                    <div class="col-md-1" style="margin:10px">
                        <span style="font-weight:bold;"></span>
                        <br><br>
                        <button type="button" class="btn btn-sm btn-outline-secondary" @click="addItem">Save</button>
                    </div>
                </div>

                <div style="zoom:0.9">
                    <h5>Rounds</h5>
                    <div class="row" style="margin-bottom:20px">
                        <div class="col-md-12" style="display:flex;">
                            <!--<div class="col-md-2"><span style="font-weight:bold;">Id</span></div>-->
                            <div class="col-md-2"><span style="font-weight:bold;">Item Type</span></div>
                            <div class="col-md-2"><span style="font-weight:bold;">Metal</span></div>
                            <div class="col-md-2"><span style="font-weight:bold;">Shape</span></div>
                            <div class="col-md-3"><span style="font-weight:bold;">Photo</span></div>
                            <div class="col-md-2"><span style="font-weight:bold;">Thumb</span></div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom:20px;">
                        <div v-for="post in filter(posts,'Round')" class="col-md-12" style="display:flex;margin-bottom:20px;">
                            <!--<div class="col-md-2">{{post.id}}</div>-->
                            <div class="col-md-2">{{post.itemType}}</div>
                            <div class="col-md-2">{{post.metalValue}}</div>
                            <div class="col-md-2">{{post.shapeValue}}</div>
                            <div class="col-md-3">
                                <div class="image" v-if="getPhotoSrc(post)!=''">
                                    <img class="btnDel" v-if="getPhotoSrc(post)!=''" v-on:click="deletePhoto(post.id, 'Photo')" src="../../public/delete.webp" />
                                    <img :src="getPhotoSrc(post)" class="imgfluid" style='width:100px;float:left; height:100px;margin-bottom:5px; margin-left:5px;border:2px solid #b06c1c;border-radius:10px;'>
                                </div>
                                <div>
                                    <input v-if="getPhotoSrc(post)==''" name="fuPhoto" type="file" ref="filePhoto" :id="getPhotoUploadId(post,1)" v-on:change="getPhotoFile">
                                    <br><br>
                                    <button type="button" v-if="getPhotoSrc(post)==''" class="btn btn-sm btn-outline-secondary"  @click="addPhoto(getPhotoUploadId(post,1))">Upload</button>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="imageT" v-if="getThumbSrc(post)!=''">
                                    <img class="btnDel" v-if="getThumbSrc(post)!=''" v-on:click="deletePhoto(post.thumbId , 'Thumb')" src="../../public/delete.webp" />
                                    <img :src="getThumbSrc(post)" class="imgfluid" style='width:70px;float:left; height:70px;margin-bottom:5px; margin-left:5px;border:2px solid #b06c1c;border-radius:10px;'>
                                </div>
                                <div>
                                    <input v-if="getThumbSrc(post)==''" name="fuPhoto" type="file" ref="filePhoto" :id="getPhotoUploadId(post,2)" v-on:change="getPhotoFile">
                                    <br><br>
                                    <button type="button" v-if="getThumbSrc(post)==''" class="btn btn-sm btn-outline-secondary" @click="addPhoto(getPhotoUploadId(post,2))">Upload</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <h5>Cushions</h5>
                    <div class="row" style="margin-bottom:20px">
                        <div class="col-md-12" style="display:flex;">
                            <!--<div class="col-md-2"><span style="font-weight:bold;">Id</span></div>-->
                            <div class="col-md-2"><span style="font-weight:bold;">Item Type</span></div>
                            <div class="col-md-2"><span style="font-weight:bold;">Metal</span></div>
                            <div class="col-md-2"><span style="font-weight:bold;">Shape</span></div>
                            <div class="col-md-3"><span style="font-weight:bold;">Photo</span></div>
                            <div class="col-md-2"><span style="font-weight:bold;">Thumb</span></div>
                        </div>
                    </div>
                    <div class="row">
                        <div v-for="post2 in filter(posts,'Cushion')" class="col-md-12" style="display:flex;margin-bottom:20px;">
                            <!--<div class="col-md-2">{{post2.id}}</div>-->
                            <div class="col-md-2">{{post2.itemType}}</div>
                            <div class="col-md-2">{{post2.metalValue}}</div>
                            <div class="col-md-2">{{post2.shapeValue}}</div>
                            <div class="col-md-3">
                                <div class="image" v-if="getPhotoSrc(post2)!=''">
                                    <img class="btnDel" v-if="getPhotoSrc(post2)!=''" v-on:click="deletePhoto(post2.id, 'Photo')" src="../../public/delete.webp" />
                                    <img :src="getPhotoSrc(post2)" class="imgfluid" style='width:100px;float:left; height:100px;margin-bottom:5px; margin-left:5px;border:2px solid #b06c1c;border-radius:10px;'>
                                </div>
                                <div>
                                    <input v-if="getPhotoSrc(post2)==''" name="fuPhoto" type="file" ref="filePhoto" :id="getPhotoUploadId(post2,1)"  v-on:change="getPhotoFile">
                                    <br><br>
                                    <button type="button" v-if="getPhotoSrc(post2)==''" class="btn btn-sm btn-outline-secondary" @click="addPhoto(getPhotoUploadId(post2,1))">Upload</button>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="imageT" v-if="getThumbSrc(post2)!=''">
                                    <img class="btnDel" v-if="getThumbSrc(post2)!=''" v-on:click="deletePhoto(post2.thumbId , 'Thumb')" src="../../public/delete.webp" />
                                    <img :src="getThumbSrc(post2)" class="imgfluid" style='width:70px;float:left; height:70px;margin-bottom:5px; margin-left:5px;border:2px solid #b06c1c;border-radius:10px;'>
                                </div>
                                <div>
                                    <input v-if="getThumbSrc(post2)==''" name="fuPhoto" type="file" ref="filePhoto" :id="getPhotoUploadId(post2,2)" v-on:change="getPhotoFile">
                                    <br><br>
                                    <button type="button" v-if="getThumbSrc(post2)==''" class="btn btn-sm btn-outline-secondary"  @click="addPhoto(getPhotoUploadId(post2,2))">Upload</button>
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
                posts: [] as diamond[],
                selectedType: -1 as number,
                selectedMetal: -1 as number,
                selectedShape: -1 as number,
                selectedPhoto: "" as string,
                selectedThumb: "" as string,
                diamondEntity: { itemTypeId: -1, metalValue: "-1", shapeValue: "-1", id: 0, thumbId: 0 } as diamond
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
            },
            getPhotoUploadId(pos: diamond, type = 0) { // thumb or photo
                if (type == 1) {
                    return "fu-" + 1 + "-" + pos.itemTypeId + "-" + pos.metalValue.replace(" ","") + "-" + pos.shapeValue.replace(" ","");
                }
                else
                    return "fu-" + 2 + "-" + pos.itemTypeId + "-" + pos.metalValue.replace(" ","") + "-" + pos.shapeValue.replace(" ","");
               
            }
            ,
            deletePhoto(photoID = 0, type = '') {
                if (type == 'Photo') {
                    //@ts-ignore:
                    this.diamondEntity.id = photoID;
                    //@ts-ignore:
                    this.diamondEntity.thumbId = 0;
                }
                else {
                    //@ts-ignore:
                    this.diamondEntity.thumbId = photoID;
                    //@ts-ignore:
                    this.diamondEntity.id = 0;
                }
                //@ts-ignore:
                //console.log(this.diamondEntity);
                //@ts-ignore:
                axios.post("http://localhost:53205/api/diamond/DeletePhoto", this.diamondEntity
                ).then((res) => {
                    this.getAll();
                    console.log(res);
                }).catch((error) => {
                    console.log(error)
                })
            },
            addItem() {

                var fPhoto = document.querySelector('#fuPhoto');
                var fThumb = document.querySelector('#fuThumb');

                //@ts-ignore:
                //console.log(this.diamondEntity);
                //@ts-ignore:
                axios.post("http://localhost:53205/api/diamond/AddItem", this.diamondEntity
                ).then((res) => {
                    //console.log(res.data);
                    var formData = new FormData();
                    formData.append("itemPhotoId", res.data.photoId)
                    formData.append("itemThumbId", res.data.thumbId)
                    // @ts-ignore:
                    formData.append("filePhoto", fPhoto.files[0]);
                    // @ts-ignore:
                    formData.append("fileThumb", fThumb.files[0]);
                    axios.post('http://localhost:53205/api/diamond/Upload', formData, {
                        headers: {
                            'Content-Type': 'multipart/form-data'
                        }
                    }).then((res) => {
                        this.getAll();
                    })
                    //console.log(res)
                }).catch((error) => {
                    console.log(error)
                })
            },
            addPhoto(fileUploadID = '') {

                fileUploadID ="#" + fileUploadID;

                var fPhoto = document.querySelector(fileUploadID);
                var formData = new FormData();
                    formData.append("fileUploadID", fileUploadID)
                    // @ts-ignore:
                    formData.append("filePhoto", fPhoto.files[0]);
                    axios.post('http://localhost:53205/api/diamond/AddPicture', formData, {
                        headers: {
                            'Content-Type': 'multipart/form-data'
                        }
                    }).then((res) => {
                        this.getAll();
                    }).catch((error) => {
                    console.log(error)
                })
            },
            // @ts-ignore:
            getPhotoFile(event) {
                //console.log(event.target.files);
            },
            // @ts-ignore:
            getThumbFile(event) {
                //console.log(event.target.files);
            },
            getAll() {
                axios.get('http://localhost:53205/api/diamond/GetDiamondsAsync')
                    .then(response => {
                        // @ts-ignore:
                        this.posts = response.data;
                    })
                    .catch((e) => {
                        console.log(e);
                    });

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
    .btnDel {
        position: absolute;
        left: 95%;
        margin-left: -10px;
        margin-top: 2px;
        cursor: pointer;
    }

    .imgfluid {
        max-width: 100%;
        height: auto;
        width: 100px;
        float: left;
        height: 100px;
        margin-bottom: 5px;
        margin-left: 5px;
        border: 2px solid #b06c1c;
        border-radius: 10px;
    }

    .noDisp {
        display: none;
    }

    .image {
        width: 100px;
        height: 100px;
        position: relative;
    }

    .imageT {
        width: 70px;
        height: 70px;
        position: relative;
    }
</style>