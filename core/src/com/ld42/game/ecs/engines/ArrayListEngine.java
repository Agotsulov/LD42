package com.ld42.game.ecs.engines;

import com.badlogic.gdx.Gdx;
import com.ld42.game.ecs.components.TextComponent;
import com.ld42.game.ecs.core.Engine;
import com.ld42.game.ecs.core.Entity;
import com.ld42.game.ecs.core.Scene;
import com.ld42.game.ecs.core.System;
import com.ld42.game.ecs.entites.ArrayListEntity;
import com.ld42.game.ecs.scenes.ArrayListScene;
import com.ld42.game.ecs.systems.TextDebugLogSystem;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public class ArrayListEngine extends Engine {

    private List<System> systems;

    private Scene current;

    public ArrayListEngine() {
        systems = new ArrayList<>();

        current = new ArrayListScene(this,"Scene1");

        Entity e = new ArrayListEntity(this,"Entity1");
        e.add(new TextComponent(this,"Component1","It's work"));

        current.add(e);

        System s = new TextDebugLogSystem(this, "System");

        systems.add(s);
    }

    @Override
    public void changeScene(Scene scene) {
        current = scene;
    }

    @Override
    public Scene getScene() {
        return current;
    }

    @Override
    public void show() {
        Gdx.app.log("ArrayListEngine","show");
    }

    @Override
    public void render(float delta) {
        Gdx.app.log("ArrayListEngine","render");
        for(int i = 0;i < size();i++)
            get(i).update();
    }

    @Override
    public void resize(int width, int height) {

    }

    @Override
    public void pause() {

    }

    @Override
    public void resume() {

    }

    @Override
    public void hide() {

    }

    @Override
    public void dispose() {

    }

    @Override
    public boolean add(System o) {
        return systems.add(o);
    }

    @Override
    public boolean contains(System o) {
        return systems.contains(o);
    }

    @Override
    public boolean remove(System o) {
        return systems.remove(o);
    }

    @Override
    public int size() {
        return systems.size();
    }

    @Override
    public System get(int i) {
        return systems.get(i);
    }
}
