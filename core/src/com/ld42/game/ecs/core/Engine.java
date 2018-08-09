package com.ld42.game.ecs.core;

import com.badlogic.gdx.Screen;

import java.util.List;

public abstract class Engine implements Screen , Container<System> {

    public abstract void changeScene(Scene scene);

    public abstract Scene getScene();

}
