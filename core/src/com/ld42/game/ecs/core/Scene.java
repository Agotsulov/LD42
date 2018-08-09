package com.ld42.game.ecs.core;

import java.util.List;

public abstract class Scene extends GameObject implements Container<Entity> {

    public Scene(Engine engine, String name) {
        super(engine, name);
    }
}
